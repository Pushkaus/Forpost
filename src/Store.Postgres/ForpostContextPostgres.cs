using Forpost.Common.EntityAnnotations;
using Forpost.Common.Utils;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
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
    public DbSet<Contractor> Contragents => Set<Contractor>();
    public DbSet<FileEntity> Files => Set<FileEntity>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Step> Issues => Set<Step>();
    public DbSet<TechCard> TechnologicalProcesses => Set<TechCard>();
    public DbSet<Operation> Operations => Set<Operation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForpostContextPostgres).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditableEntries = ChangeTracker.Entries<IAuditableEntity>().ToArray();

        if (auditableEntries.Length == 0)
            return await base.SaveChangesAsync(cancellationToken);
        
        var userId = _identityProvider.GetUserId() ?? 
                     throw new InvalidOperationException("Пользователи, модифицирующий сущности обязан быть авторизованным");
        
        foreach (var entry in auditableEntries)
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = _timeProvider.GetUtcNow();
                    entry.Entity.CreatedById = userId;
                    entry.Entity.UpdatedAt = _timeProvider.GetUtcNow();
                    entry.Entity.UpdatedById = userId;
                    break;
                case EntityState.Modified:
                    entry.Property(e => e.CreatedAt).IsModified = false;
                    entry.Property(e => e.CreatedById).IsModified = false;
                    entry.Entity.UpdatedAt = _timeProvider.GetUtcNow();
                    entry.Entity.UpdatedById = userId;
                    break;
                case EntityState.Deleted:
                    entry.Entity.DeletedAt = _timeProvider.GetUtcNow();
                    entry.Entity.DeletedById = userId;
                    entry.State = EntityState.Modified;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}