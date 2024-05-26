using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres;

public sealed class OrderBlockContext : DbContext
{
    public OrderBlockContext(DbContextOptions<OrderBlockContext> options) : base(options) { }

    public DbSet<OrderBlock> OrderBlocks => Set<OrderBlock>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderBlock>().ToTable("order_blocks");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderBlockContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}