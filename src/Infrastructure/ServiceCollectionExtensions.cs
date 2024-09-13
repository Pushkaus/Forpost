using Forpost.Infrastructure.Pipeline;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Transient);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));
        
        return services;
    }
}