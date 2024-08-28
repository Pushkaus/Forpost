using System.Text;
using Forpost.Application;
using Forpost.Application.Auth;
using Forpost.Common.Utils;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Store.Postgres;
using Forpost.Web.Contracts;
using Forpost.Web.Host.Infrastructure;
using Forpost.Web.Host.Infrastructure.Auth;
using Forpost.Web.Host.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Forpost.Web.Host;

internal sealed class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationLayer();
        services.AddOpenTelemetryLogging(_configuration);

        services.AddSingleton<IIdentityProvider, IdentityProvider>();
        services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
        services.AddScoped<IPasswordHasher<RegisterUserCommand>, PasswordHasher<RegisterUserCommand>>();

        services.AddForpostContextPostgres(_configuration);
        services.AddSwaggerServices();
        services.AddSingleton(TimeProvider.System);

        services.AddControllers();

        services.AddAutoMapper(WebContractsAssemblyReference.Assembly);
        services.AddAutoMapper(ApplicationAssemblyReference.Assembly);

        services.AddHttpContextAccessor();
        services.AddControllers(options => options.Filters.Add<ForpostExceptionFilter>());
        services.AddEndpointsApiExplorer();

        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key") ??
                                          throw new AggregateException("Не указан Seq:ServerUri"));
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        ConfigureCors(services);
    }

    private static void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(options => options.AddDefaultPolicy(policy =>
            policy.WithOrigins("http://localhost:3000", "http://localhost:4200", "http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()));
    }

    public static void Configure(IApplicationBuilder app)
    {
        app.UseCors();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "ForpostApi");
            options.RoutePrefix = string.Empty;
        });
        app.UseHttpRequestLoggingWithEmployeeId();
        app.UseEndpoints(options => options.MapControllers());
    }
}