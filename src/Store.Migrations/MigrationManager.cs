using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Forpost.Store.Migrations;

public static class MigrationManager
{
    public static async Task MigrateSchema() => 
        await Migrate<ForpostContextPostgres, SchemaMigrationContextFactory>().ConfigureAwait(false);

    public static async Task MigrateData() => 
        await Migrate<DataMigrationsContext, DataMigrationContextFactory>().ConfigureAwait(false);

    private static async Task Migrate<TDbContext, TDbContextFactory>()
        where TDbContext : DbContext
        where TDbContextFactory : IDesignTimeDbContextFactory<TDbContext>, new()
    {
        var dbContextFactory = new TDbContextFactory();
        await using var dbContext = dbContextFactory.CreateDbContext(Array.Empty<string>());
        
        await dbContext.Database.MigrateAsync().ConfigureAwait(false);
    }
}