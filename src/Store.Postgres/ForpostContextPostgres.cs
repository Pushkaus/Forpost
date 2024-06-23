using Forpost.Store.Entities;
using Forpost.Store.Postgres.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Forpost.Store.Postgres;
public sealed class ForpostContextPostgres : DbContext

{
    public ForpostContextPostgres(DbContextOptions<ForpostContextPostgres> options) : base(options) { }
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceProduct> InvoiceProducts => Set<InvoiceProduct>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<ProductAssembly> ProductAssemblies => Set<ProductAssembly>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForpostContextPostgres).Assembly);
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductAssemblyConfiguration());


        base.OnModelCreating(modelBuilder);
        
    }
}