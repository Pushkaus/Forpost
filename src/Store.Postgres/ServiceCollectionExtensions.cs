using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Store.Postgres;

public static class ServiceCollectionExtensions
{
    private const string ConnectionName = "DornContext";
    
    public static IServiceCollection AddPostgresDbContext(this IServiceCollection services)
    {
        services.AddDbContext<OrdersBlocks>((provider, builder) =>
        {
            var connectionString = provider.GetRequiredService<IConfiguration>().GetConnectionString(ConnectionName)
                                   ?? throw new InvalidOperationException($"Не удалось получить строку подключения: {ConnectionName}");

            builder.UseNpgsql(connectionString);
        });

        return services;
    }
}

