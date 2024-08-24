using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Entities.ProductCreating;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres;

public sealed class ForpostContextPostgres : DbContext
{
    public ForpostContextPostgres(DbContextOptions<ForpostContextPostgres> options) : base(options)
    {
    }

    public DbSet<EmployeeEntity> Employees => Set<EmployeeEntity>();
    public DbSet<RoleEntity> Roles => Set<RoleEntity>();
    public DbSet<InvoiceEntity> Invoices => Set<InvoiceEntity>();
    public DbSet<InvoiceProductEntity> InvoiceProducts => Set<InvoiceProductEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<StorageEntity> Storages => Set<StorageEntity>();
    public DbSet<StorageProductEntity> StorageProducts => Set<StorageProductEntity>();
    public DbSet<ContractorEntity> Contractors => Set<ContractorEntity>();
    public DbSet<FileEntity> Files => Set<FileEntity>();
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    public DbSet<IssueEntity> Issues => Set<IssueEntity>();
    public DbSet<TechCardEntity> TechCards => Set<TechCardEntity>();
    public DbSet<TechCardItemEntity> TechCardItems => Set<TechCardItemEntity>();
    public DbSet<TechCardStepEntity> TechCardSteps => Set<TechCardStepEntity>();
    public DbSet<OperationEntity> Operations => Set<OperationEntity>();
    public DbSet<StepEntity> Steps => Set<StepEntity>();
    public DbSet<CompletedProductEntity> CompletedProducts => Set<CompletedProductEntity>();
    public DbSet<ManufacturingProcessEntity> ManufacturingProcesses => Set<ManufacturingProcessEntity>();
    public DbSet<ProductDevelopmentEntity> ProductDevelopments => Set<ProductDevelopmentEntity>();
    public DbSet<ProductVersionEntity> ProductVersions => Set<ProductVersionEntity>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForpostContextPostgres).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}