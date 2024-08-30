using Forpost.Pipeline;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            options.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });
        
        return services.AddRepositories();
    }
}