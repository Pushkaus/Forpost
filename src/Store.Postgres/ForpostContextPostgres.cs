using Forpost.Domain.Catalogs.Category;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.Catalogs.Operations;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Roles;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Domain.CRM.IssueHistory;
using Forpost.Domain.InvoiceManagement;
using Forpost.Domain.MessageManager;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Domain.ProductCreating.CompositionProduct;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Forpost.Domain.SortOut;
using Forpost.Domain.StorageManagment;
using Microsoft.EntityFrameworkCore;
using File = Forpost.Domain.FileStorage.File;

namespace Forpost.Store.Postgres;

public sealed class ForpostContextPostgres : DbContext
{
    public ForpostContextPostgres(DbContextOptions<ForpostContextPostgres> options) : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceProduct> InvoiceProducts => Set<InvoiceProduct>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Storage> Storages => Set<Storage>();
    public DbSet<StorageProduct> StorageProducts => Set<StorageProduct>();
    public DbSet<Contractor> Contractors => Set<Contractor>();
    public DbSet<File> Files => Set<File>();
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
    public DbSet<ProductVersion> ProductVersions => Set<ProductVersion>();
    public DbSet<CompositionProduct> CompositionProducts => Set<CompositionProduct>();
    public DbSet<NotificationForUsers> NotificationsForUsers => Set<NotificationForUsers>();
    public DbSet<IssueHistory> IssueHistories => Set<IssueHistory>();
    #region ApplicationTables
    
    /// <summary>
    /// Исходящие сообщения
    /// </summary>
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
    
    #endregion
   


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForpostContextPostgres).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}