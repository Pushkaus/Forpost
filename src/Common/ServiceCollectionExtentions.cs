using Forpost.Common.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Common;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddIdentityProvider(this IServiceCollection services)
    {
        services.AddSingleton<IIdentityProvider, IdentityProvider>();
        return services;
    }
}