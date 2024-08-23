using Forpost.Common.EntityAnnotations;
using Forpost.Common.Utils;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Entities.ProductCreating;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Forpost.Store.Postgres;

public sealed class ForpostContextPostgres : DbContext
{
    private readonly IIdentityProvider _identityProvider;
    private readonly TimeProvider _timeProvider;
    public ForpostContextPostgres(DbContextOptions<ForpostContextPostgres> options,
         IIdentityProvider identityProvider, TimeProvider timeProvider) : base(options)
    {
        _identityProvider = identityProvider;
        _timeProvider = timeProvider;
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceProduct> InvoiceProducts => Set<InvoiceProduct>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Storage> Storages => Set<Storage>();
    public DbSet<StorageProduct> StorageProducts => Set<StorageProduct>();
    public DbSet<Contractor> Contractors => Set<Contractor>();
    public DbSet<FileEntity> Files => Set<FileEntity>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Issue> Issues => Set<Issue>();
    public DbSet<TechCard> TechCards => Set<TechCard>();
    public DbSet<TechCardItem> TechCardItems => Set<TechCardItem>();
    public DbSet<TechCardStep> TechCardSteps => Set<TechCardStep>();
    public DbSet<Operation> Operations => Set<Operation>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<CompletedProduct> CompletedProducts => Set<CompletedProduct>();
    public DbSet<ManufacturingProcess> ManufacturingProcesses => Set<ManufacturingProcess>();
    public DbSet<ProductDevelopment> ProductDevelopments => Set<ProductDevelopment>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForpostContextPostgres).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}