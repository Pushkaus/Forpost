using Forpost.Store.Entities;
using Forpost.Store.Postgres.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Task = Forpost.Store.Entities.Works;

namespace Forpost.Store.Postgres;

public sealed class OrderBlockContext : DbContext
{
    public OrderBlockContext(DbContextOptions<OrderBlockContext> options) : base(options) { }

    public DbSet<OrderBlock> OrderBlocks => Set<OrderBlock>();

    public  DbSet<SettingsBlock> SettingsBlocks => Set<SettingsBlock>();
    //public  DbSet<SettingsBlocksHistory> SettingsBlocksHistories => Set<SettingsBlocksHistory>();

    //public  DbSet<Specification> Specifications => Set<Specification>();

    public  DbSet<Staff> Staff => Set<Staff>();
    //public  DbSet<StaffRoleStaffView> StaffRoleStaffViews => Set<StaffRoleStaffView>();

    //public DbSet<Task> Tasks => Set<Task>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderBlock>().ToTable("order_blocks");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderBlockContext).Assembly);
        modelBuilder.ApplyConfiguration(new SettingsBlocksConfiguration());

        base.OnModelCreating(modelBuilder);
        
    }
}