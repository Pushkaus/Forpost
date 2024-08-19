using Forpost.Common;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Store.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddAllTypesAssignableMarkerInterfaceTo<IRepository>(ServiceLifetime.Transient);
    }
}