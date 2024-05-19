using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres;

public sealed class OrdersBlocks : DbContext
{
    public OrdersBlocks(DbContextOptions<OrdersBlocks> options) : base(options) { }

    public DbSet<OrderBlock> OrderBlock => Set<OrderBlock>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersBlocks).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}