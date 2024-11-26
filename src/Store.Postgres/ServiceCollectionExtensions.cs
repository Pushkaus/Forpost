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
        services.AddSingleton<ChangeHistoryInterceptor>();
        services.AddSingleton<DomainEventToOutboxMessageInterceptor>();

        services.AddDbContext<ForpostContextPostgres>((serviceProvider, options) =>
        {
            var connectionString = configuration.GetConnectionString(ConnectionName)
                                   ?? throw new InvalidOperationException(
                                       $"Не удалось получить строку подключения: {ConnectionName}");

            var domainEventInterceptor = serviceProvider.GetRequiredService<DomainEventToOutboxMessageInterceptor>();
            var changeHistoryInterceptor = serviceProvider.GetRequiredService<ChangeHistoryInterceptor>();
            
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            options.UseNpgsql(connectionString)
                .AddInterceptors(domainEventInterceptor, changeHistoryInterceptor)
                .EnableSensitiveDataLogging();
        });

        return services;
    }
}