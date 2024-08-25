﻿using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Forpost.Store.Migrations;

internal abstract class ContextFactory<TDbContext> : IDesignTimeDbContextFactory<TDbContext> where TDbContext : DbContext
{
    private const string ConnectionName = "ErpDatabase";

    private TDbContext CreateContext(DbContextOptionsBuilder<TDbContext> options)
        => (TDbContext?)Activator.CreateInstance(typeof(TDbContext), options.Options)
           ?? throw new InvalidOperationException();

    protected virtual Action<NpgsqlDbContextOptionsBuilder> PostgresOptions =>
        builder => builder.MigrationsAssembly(typeof(ContextFactory<TDbContext>).Assembly.FullName);

    public TDbContext CreateDbContext(string[] args) => CreateContext(CreateDbContextOptions());

    protected DbContextOptionsBuilder<TDbContext> CreateDbContextOptions() =>
        new DbContextOptionsBuilder<TDbContext>().UseNpgsql(GetConnectionString(), PostgresOptions);

    protected string GetConnectionString()
        => Configuration.GetConnectionString(ConnectionName) ?? throw new InvalidOperationException(
               $"Не удалось получить строку подключения {ConnectionName}");

    protected IConfiguration Configuration =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

}

/// <summary>
/// Контекст для миграции данных (Sql scripts)
/// </summary>
internal sealed class DataMigrationsContext : DbContext
{
    public DataMigrationsContext(DbContextOptions options) : base(options) { }

}

internal sealed class DataMigrationContextFactory : ContextFactory<DataMigrationsContext>
{
    protected override Action<NpgsqlDbContextOptionsBuilder> PostgresOptions => builder =>
    {
        base.PostgresOptions.Invoke(builder);
        builder.MigrationsHistoryTable("__EFDataMigrationsHistory");
        builder.CommandTimeout((int)TimeSpan.FromSeconds(60).TotalSeconds);
    };
}

internal sealed class SchemaMigrationContextFactory : ContextFactory<ForpostContextPostgres>;