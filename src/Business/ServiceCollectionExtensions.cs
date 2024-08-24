using Forpost.Common;
using Forpost.EventBus;
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
}