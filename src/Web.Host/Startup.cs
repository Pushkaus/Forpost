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
using Forpost.Business;
using Forpost.Common;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models;
using Forpost.Web.Contracts;
using Forpost.Web.Contracts.Controllers.InvoiceProducts;
using Forpost.Web.Contracts.Controllers.StorageProduct;
using Forpost.Web.Contracts.Controllers.SubProduct;
using Forpost.Web.Contracts.ProductOperations;
using Forpost.Web.Contracts.Products;
using Forpost.Web.Contracts.Storage;
using Forpost.Web.Host.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

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
        // Регистрация сервисов
        services.AddBusinessServices();
        
        services.AddIdentityProvider();
        // Регистрация политики CORS
        ConfigureCors(services);

        // Регистрация контроллеров
        services.AddControllers();

        // Регистрация базы данных
        services.AddForpostContextPostgres(_configuration);

        // Регистрация `IPasswordHasher<Employee>`
        services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
        // Регистрация автомаппера
        services.AddAutoMapper(WebAssemblyReference.Assembly);
        services.AddAutoMapper(BusinessAssemblyReference.Assembly);
        // Регистрация IHttpContextAccessor
        services.AddHttpContextAccessor();
        // Конфигурация Swagger
        ConfigureSwagger(services);

        // Регистрация API Explorer
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
                ValidateIssuerSigningKey = true, // Валидация секретного ключа
                IssuerSigningKey = new SymmetricSecurityKey(key), // Установка ключа безопастности
                ValidateIssuer = false, // Строка, представляющая издателя
                ValidateAudience = false // Установка потребителя токена
            };
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            // Настройка схемы безопасности
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

    }
    // Настройка CORS
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
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(EmployeeController).Assembly.GetName().Name}.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(ProductController).Assembly.GetName().Name}.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(StorageController).Assembly.GetName().Name}.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(StorageProductController).Assembly.GetName().Name}.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(SubProductController).Assembly.GetName().Name}.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(ProductOperationController).Assembly.GetName().Name}.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(InvoiceProductController).Assembly.GetName().Name}.xml"));
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
        app.UseHttpsRedirection();
    }
}