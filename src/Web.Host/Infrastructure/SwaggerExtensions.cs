using Forpost.Web.Contracts;
using Microsoft.OpenApi.Models;

namespace Forpost.Web.Host.Infrastructure;

internal static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Forpost API",
                Version = "v1",
                Description = "Forpost API - апи для работы с техпроцессами"
            });
            var xmlFile = $"{WebContractsAssemblyReference.Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}