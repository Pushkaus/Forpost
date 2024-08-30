using Forpost.Features;
using Forpost.Infrastructure.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<FeatureAssemblyReference>();
            options.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });
        
        return services;
    }
}