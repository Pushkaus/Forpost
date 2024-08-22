using Forpost.Common.EntityAnnotations;
using Forpost.Common.Extensions;
using Forpost.Common.Utils;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Forpost.Store.Repositories;

//TODO:Добавить тест, который проверяет, что в нем есть все существующие репозитории.
internal sealed class DbUnitOfWork : IDbUnitOfWork
{
    private readonly ForpostContextPostgres _dbContext;
    private readonly IIdentityProvider _identityProvider;
    private readonly TimeProvider _timeProvider;
    
    public DbUnitOfWork(ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IIdentityProvider identityProvider,
        IContragentRepository contragentRepository,
        IEmployeeRepository employeeRepository,
        IFilesRepository filesRepository, 
        IInvoiceRepository invoiceRepository, 
        IProductRepository productRepository,
        IRoleRepository roleRepository, 
        IStorageProductRepository storageProductRepository,
        IStorageRepository storageRepository,
        IInvoiceProductRepository invoiceProductRepository)
    {
        _dbContext = dbContext;
        _timeProvider = timeProvider;
        _identityProvider = identityProvider;
        ContragentRepository = contragentRepository;
        EmployeeRepository = employeeRepository;
        FilesRepository = filesRepository;
        InvoiceRepository = invoiceRepository;
        ProductRepository = productRepository;
        RoleRepository = roleRepository;
        StorageProductRepository = storageProductRepository;
        StorageRepository = storageRepository;
        InvoiceProductRepository = invoiceProductRepository;
    }

    public IContragentRepository ContragentRepository { get; }
    public IEmployeeRepository EmployeeRepository { get; }
    public IFilesRepository FilesRepository { get; }
    public IInvoiceProductRepository InvoiceProductRepository { get; }
    public IInvoiceRepository InvoiceRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IStorageProductRepository StorageProductRepository { get; }
    public IStorageRepository StorageRepository { get; }
    
    public IDbContextTransaction BeginTransaction() => _dbContext.Database.BeginTransaction();
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditableEntries = _dbContext.ChangeTracker.Entries<IAuditableEntity>().ToArray();
        
        if (auditableEntries.IsNotEmpty())
            return await SaveChangesWithAuditAsync(auditableEntries, cancellationToken);
        
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<int> SaveChangesWithAuditAsync(EntityEntry<IAuditableEntity>[] auditableEntries, CancellationToken cancellationToken)
    {
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
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}