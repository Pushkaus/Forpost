using System.Reflection;
using Forpost.Store.Postgres;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Forpost.Business;
using Forpost.Business.Settings;
using Forpost.Common;
using Forpost.Store.Entities;
using Forpost.Web.Contracts.Controllers.Component;
using Forpost.Web.Contracts.Controllers.Employees;
using Forpost.Web.Contracts.Controllers.InvoiceProducts;
using Forpost.Web.Contracts.Controllers.Products;
using Forpost.Web.Contracts.Controllers.Storage;
using Forpost.Web.Contracts.Controllers.StorageProduct;
using Forpost.Web.Contracts.Settings;
using Forpost.Web.Host.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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
        services.AddBusinessServices();
        
        services.AddIdentityProvider();
        
        ConfigureCors(services);
        
        services.AddControllers();


        services.AddForpostContextPostgres(_configuration);
        
        services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
        
        services.AddAutoMapper(WebAssemblyReference.Assembly);
        services.AddAutoMapper(BusinessAssemblyReference.Assembly);
        
        services.AddHttpContextAccessor();
        services.AddControllers(x => x.Filters.Add<ForpostExceptionFilter>());
        
        ConfigureSwagger(services);
        
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
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, 
                ValidateAudience = false 
            };
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
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
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                policy.WithOrigins("http://localhost:5173")
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
            options.CustomOperationIds(apiDesc =>
            {
                var controllerName = "";
                if (apiDesc.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    controllerName = controllerActionDescriptor.ControllerName;
                }

                return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? $"{controllerName}{methodInfo.Name}" : null;
            });
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
                $"{typeof(ComponentController).Assembly.GetName().Name}.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(InvoiceProductController).Assembly.GetName().Name}.xml"));
            
        });
        
    }

    public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
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