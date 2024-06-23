using Forpost.Business.Abstract.Services;
using Forpost.Business.Services;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Forpost.Store.Entities;
using Forpost.Web.Contracts.Account;
using Microsoft.AspNetCore.Identity;

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
        // ����������� ��������
        RegisterServices(services);

        // ����������� �������� CORS
        ConfigureCors(services);

        // ����������� ������������
        services.AddControllers();

        // ����������� ���� ������
        services.AddForpostContextPostgres(_configuration);

        // ����������� �����������
        services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            options.AddPolicy("RequireSetuperRole", policy => policy.RequireRole("Setuper"));
            options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));

        });
        // ����������� `IPasswordHasher<Employee>`
        services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();

        // ������������ Swagger
        ConfigureSwagger(services);

        // ����������� API Explorer
        services.AddEndpointsApiExplorer();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
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
                ValidateIssuerSigningKey = true, // ��������� ���������� �����
                IssuerSigningKey = new SymmetricSecurityKey(key), // ��������� ����� �������������
                ValidateIssuer = false, // ������, �������������� ��������
                ValidateAudience = false // ��������� ����������� ������
            };
        });

    }
    private void RegisterServices(IServiceCollection services)
    {
        //��������������
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<IAccountService, AccountService>();
    }
    // ��������� CORS
    private void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            });
        });
    }

    private void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(AccountController).Assembly.GetName().Name}.xml"));
            
        });
    }

    public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, ILogger<Startup> logger)
    {
        app.UseCors();
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(options =>
            options.MapControllers());
    }
}