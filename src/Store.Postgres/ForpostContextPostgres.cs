using Forpost.Store.Entities;
using Forpost.Store.Postgres.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using Forpost.Common.EntityAnnotations;
using Forpost.Common.Utils;
using Microsoft.AspNetCore.Http;

namespace Forpost.Store.Postgres;
public  class ForpostContextPostgres : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IIdentityProvider _identityProvider;
    public ForpostContextPostgres(DbContextOptions<ForpostContextPostgres> options, IHttpContextAccessor httpContextAccessor, IIdentityProvider identityProvider) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _identityProvider = identityProvider;
    }
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceProduct> InvoiceProducts => Set<InvoiceProduct>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Storage> Storages => Set<Storage>();
    public DbSet<StorageProduct> StorageProducts => Set<StorageProduct>();
    public DbSet<Contragent> Contragents => Set<Contragent>();
    public DbSet<FileEntity> Files => Set<FileEntity>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Issue> Issues => Set<Issue>();
    public DbSet<TechnologicalCard> TechnologicalProcesses => Set<TechnologicalCard>();
    public DbSet<Operation> Operations => Set<Operation>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForpostContextPostgres).Assembly);
        base.OnModelCreating(modelBuilder);
        
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditableEntries = ChangeTracker.Entries<IAuditableEntity>();

        if (auditableEntries.Any())
        {
            var userId = _identityProvider.GetUserId();
            foreach (var entry in auditableEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                        entry.Entity.CreatedById = userId;
                        entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                        entry.Entity.UpdatedById = userId;
                        break;
                    case EntityState.Modified:
                        entry.Property(e => e.CreatedAt).IsModified = false;
                        entry.Property(e => e.CreatedById).IsModified = false;
                        entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                        entry.Entity.UpdatedById = userId;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedAt = DateTimeOffset.UtcNow;
                        entry.Entity.DeletedById = userId;
                        entry.State = EntityState.Modified;
                        break;
                        
                }
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}