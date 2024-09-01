using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Forpost.Store.Migrations;

public static class MigrationManager
{
    private const string ConnectionName = "ErpDatabase";
    
    public static async Task MigrateSchema(IConfiguration configuration) =>
        await Migrate<ForpostContextPostgres, SchemaMigrationContextFactory>(configuration).ConfigureAwait(false);

    public static async Task MigrateData(IConfiguration configuration) =>
        await Migrate<DataMigrationsContext, DataMigrationContextFactory>(configuration).ConfigureAwait(false);

    private static async Task Migrate<TDbContext, TDbContextFactory>(IConfiguration configuration)
        where TDbContext : DbContext
        where TDbContextFactory : IDesignTimeDbContextFactory<TDbContext>, new()
    {
        var dbContextFactory = new TDbContextFactory();
        await using var dbContext = dbContextFactory.CreateDbContext(Array.Empty<string>());

        dbContext.Database.SetConnectionString(configuration.GetConnectionString(ConnectionName));
        await dbContext.Database.MigrateAsync().ConfigureAwait(false);
    }
}