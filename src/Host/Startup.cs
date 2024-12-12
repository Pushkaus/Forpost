using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Forpost.BackgroundJobs;
using Forpost.Common.Utils;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Features;
using Forpost.Features.Auth;
using Forpost.Infrastructure;
using Forpost.Store.Postgres;
using Forpost.TelegramBot;
using Forpost.Web.Contracts;
using Forpost.Web.Host;
using Forpost.Web.Host.Infrastructure;
using Forpost.Web.Host.Infrastructure.Auth;
using Forpost.Web.Host.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Forpost.Host;

internal sealed class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) => _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationLayer();
        services.AddOpenTelemetryLogging(_configuration);

        services.AddBackgroundJobs();
        services.AddInfrastructure();

        services.AddSingleton<IIdentityProvider, IdentityProvider>();

        services.AddTelegramBot(_configuration);
        services.AddHostedService<TelegramPollingService>();

        services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
        services.AddScoped<IPasswordHasher<RegisterUserCommand>, PasswordHasher<RegisterUserCommand>>();

        services.AddForpostContextPostgres(_configuration);
        
        services.AddSwaggerServices();
        services.AddSingleton(TimeProvider.System);
        
        services.AddControllers();

        services.AddAutoMapper(WebContractsAssemblyReference.Assembly);
        services.AddAutoMapper(FeatureAssemblyReference.Assembly);

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<FeatureAssemblyReference>();

        services.AddHttpContextAccessor();
        services.AddControllers(options => options.Filters.Add<ForpostExceptionFilter>());
        services.AddEndpointsApiExplorer();
        services.AddHostedService<ApplicationNotificationInitializer>();
        
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
            x.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                }
            };
        });
        ConfigureCors(services);
    }

    private static void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(options => options.AddDefaultPolicy(policy =>
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));
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
            options.SwaggerEndpoint("/swagger/v1/swagger.json", HostConstants.Name);
            options.RoutePrefix = string.Empty;
        });

        app.UseHttpRequestLoggingWithEmployeeId();
        app.UseEndpoints(options => options.MapControllers());
    }
}