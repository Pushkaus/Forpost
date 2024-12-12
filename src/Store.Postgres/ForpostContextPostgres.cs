using Forpost.Common.ApplicationNotifications;
using Forpost.Domain.Catalogs.Barcodes;
using Forpost.Domain.Catalogs.Category;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.Catalogs.Operations;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Products.ProductAttributes;
using Forpost.Domain.Catalogs.Products.ProductCompatibilities;
using Forpost.Domain.Catalogs.Roles;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.CRM.IssueHistory;
using Forpost.Domain.CRM.PriceLists;
using Forpost.Domain.MessagesManagement;
using Forpost.Domain.MessagesManagement.ApplicationNotifications;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Domain.ProductCreating.CompositionProduct;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Forpost.Domain.StorageManagment.EntryStorageHistories;
using Forpost.Domain.StorageManagment.StorageProducts;
using Microsoft.EntityFrameworkCore;
using File = Forpost.Domain.FileStorage.File;
using Attribute = Forpost.Domain.Catalogs.Products.Attributes.Attribute;

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
    public DbSet<ContractorRepresentative> ContractorRepresentatives => Set<ContractorRepresentative>();
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
    public DbSet<CompositionProduct> CompositionProducts => Set<CompositionProduct>();
    public DbSet<NotificationForUsers> NotificationsForUsers => Set<NotificationForUsers>();
    public DbSet<CompositionInvoice> CompositionInvoices => Set<CompositionInvoice>();
    public DbSet<IssueHistory> IssueHistories => Set<IssueHistory>();
    public DbSet<PriceList> PriceLists => Set<PriceList>();
    public DbSet<ProductBarcode> ProductBarcodes => Set<ProductBarcode>();
    public DbSet<EntryStorageHistory> EntryStorageHistories => Set<EntryStorageHistory>();
    public DbSet<Attribute> Attributes => Set<Attribute>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<ProductCompatibility> ProductCompatibilities => Set<ProductCompatibility>();
    public DbSet<ManufacturingOrder> ManufacturingOrders => Set<ManufacturingOrder>();
    public DbSet<ManufacturingOrderComposition> ManufacturingOrderCompositions => Set<ManufacturingOrderComposition>();
    public DbSet<ApplicationUserNotification> ApplicationUserNotifications => Set<ApplicationUserNotification>();

    #region ApplicationTables
    
    /// <summary>
    /// Исходящие сообщения
    /// </summary>
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
    public DbSet<ChangeHistory> ChangeHistory => Set<ChangeHistory>();
    public DbSet<ApplicationNotification> ApplicationNotifications => Set<ApplicationNotification>();
    
    #endregion
   


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForpostContextPostgres).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}