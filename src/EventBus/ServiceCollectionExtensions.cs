using Forpost.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.EventBus;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainEventBus(this IServiceCollection services)
    {
        services.AddTransient<IDomainEventBus, InMemoryDomainEventBus>();
        services.AddAllTypesAssignableMarkerInterfaceTo<IDomainEventHandler>(ServiceLifetime.Transient);

        return services;
    }
}