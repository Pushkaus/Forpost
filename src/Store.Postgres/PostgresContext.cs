using Forpost.Store.Entities;
using Forpost.Store.Postgres.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Forpost.Store.Postgres;

public sealed class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }
    public DbSet<OrderBlock> OrderBlocks { get; set; }
    public DbSet<Staff> Staff { get; set; } 
    public DbSet<InvoiceIssued> InvoiceIssueds { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    public DbSet<SettingsBlock> SettingsBlocks{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresContext).Assembly);
        base.OnModelCreating(modelBuilder);
        
    }
}