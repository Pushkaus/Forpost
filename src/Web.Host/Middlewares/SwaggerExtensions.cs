using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Forpost.Web.Host.Middlewares;

public static class SwaggerExtensions
{
    public static SwaggerGenOptions AddIncludeXmlComments(this SwaggerGenOptions options)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var controllerTypes = assembly.GetTypes()
            .Where(type => type.IsSubclassOf(typeof(ControllerBase)));

        foreach (var type in controllerTypes)
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{type.Assembly.GetName().Name}.xml"));
        return options;
    }
}