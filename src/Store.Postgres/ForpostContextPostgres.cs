using Forpost.Store.Entities;
using Forpost.Store.Postgres.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using Forpost.Store.Contracts;
using Microsoft.AspNetCore.Http;

namespace Forpost.Store.Postgres;
public  class ForpostContextPostgres : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ForpostContextPostgres(DbContextOptions<ForpostContextPostgres> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceProduct> InvoiceProducts => Set<InvoiceProduct>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductOperation> ProductOperations => Set<ProductOperation>();
    public DbSet<Storage> Storages => Set<Storage>();
    public DbSet<StorageProduct> StorageProducts => Set<StorageProduct>();
    public DbSet<SubProduct> SubProducts => Set<SubProduct>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForpostContextPostgres).Assembly);
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductWorkConfiguration());
        modelBuilder.ApplyConfiguration(new StorageConfiguration());
        modelBuilder.ApplyConfiguration(new StorageProductConfiguration());
        modelBuilder.ApplyConfiguration(new SubProductConfiguration());
        base.OnModelCreating(modelBuilder);
        
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditableEntries = ChangeTracker.Entries<IAuditableEntity>();

        if (auditableEntries.Any())
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim != null && Guid.TryParse(userIdClaim, out var userId))
            {
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
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}