using Forpost.Application.Contracts;
using Forpost.Common;
using Forpost.Common.DataAccess;
using Forpost.Domain.Primitives.DomainAbstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Store.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddDomainRepositories()
            .AddApplicationRepositories().AddScoped<IDbUnitOfWork, DbUnitOfWork>();

    private static IServiceCollection AddDomainRepositories(this IServiceCollection services) =>
        services.AddAllTypesAssignableMarkerInterfaceTo<IDomainRepository>(RepositoryAssemblyReference.Assembly,
            ServiceLifetime.Transient);

    private static IServiceCollection AddApplicationRepositories(this IServiceCollection services) =>
        services.AddAllTypesAssignableMarkerInterfaceTo<IApplicationReadRepository>(
            RepositoryAssemblyReference.Assembly, ServiceLifetime.Transient);
}