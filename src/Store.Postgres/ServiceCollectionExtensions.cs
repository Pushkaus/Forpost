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
        services.AddDbContext<ForpostContextPostgres>((_, options) =>
        {
            var connectionString = configuration.GetConnectionString(ConnectionName)
                                   ?? throw new InvalidOperationException(
                                       $"Не удалось получить строку подключения: {ConnectionName}");

            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}