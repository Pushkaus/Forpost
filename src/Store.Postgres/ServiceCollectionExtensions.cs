using Forpost.Store.Postgres.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Store.Postgres;

public static class ServiceCollectionExtensions
{
    private const string ConnectionName = "ErpDatabase";

    public static IServiceCollection AddForpostContextPostgres(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<DomainEventToOutboxMessageInterceptor>();
        
        services.AddDbContext<ForpostContextPostgres>((serviceProvider, options) =>
        {
            var connectionString = configuration.GetConnectionString(ConnectionName)
                                   ?? throw new InvalidOperationException(
                                       $"Не удалось получить строку подключения: {ConnectionName}");
            
            var interceptor = serviceProvider.GetRequiredService<DomainEventToOutboxMessageInterceptor>();
            
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseNpgsql(connectionString).AddInterceptors(interceptor);
        });

        return services;
    }
}