using Forpost.Business.Abstract;
using Forpost.Business.EventHanding;
using Forpost.Common;
using Forpost.Store.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Business;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAllTypesAssignableMarkerInterfaceTo<IBusinessService>(ServiceLifetime.Transient);

        services.AddRepositories();
        services.AddDomainEventBus();
        return services;
    }

    private static IServiceCollection AddDomainEventBus(this IServiceCollection services)
    {
        services.AddTransient<IDomainEventBus, InMemoryDomainEventBus>();
        services.AddAllTypesAssignableMarkerInterfaceTo<IDomainEventHandler>(ServiceLifetime.Transient);

        return services;
    }
}