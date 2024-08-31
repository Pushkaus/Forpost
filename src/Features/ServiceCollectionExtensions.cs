using Forpost.Store.Repositories;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Features;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
       
        
        return services.AddRepositories();
    }
}