using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Forpost.Store.Postgres;

public static class ServiceCollectionExtensions
{
    private const string ConnectionName = "DBContext";

    public static IServiceCollection AddForpostContextPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ForpostContextPostgres>((provider, builder) =>
        {
            var connectionString = configuration.GetConnectionString(ConnectionName)
                                   ?? throw new InvalidOperationException($"Не удалось получить строку подключения: {ConnectionName}");

            builder.UseNpgsql(connectionString);
            
        });

        return services;
    }
}
