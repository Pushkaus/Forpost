using Forpost.Common.EntityAnnotations;
using Forpost.Common.Extensions;
using Forpost.Common.Utils;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;
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
        IInvoiceProductRepository invoiceProductRepository,
        IOperationRepository operationRepository,
        IStepRepository stepRepository,
        ITechCardItemRepository techCardItemRepository,
        ITechCardRepository techCardRepository,
        ITechCardStepRepositrory techCardStepRepository,
        ICategoryRepository categoryRepository,
        IManufacturingProcessRepository manufacturingProcessRepository,
        IIssueRepository issueRepository)
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
        OperationRepository = operationRepository;
        StepRepository = stepRepository;
        TechCardItemRepository = techCardItemRepository;
        TechCardRepository = techCardRepository;
        TechCardStepRepository = techCardStepRepository;
        CategoryRepository = categoryRepository;
        ManufacturingProcessRepository = manufacturingProcessRepository;
        IssueRepository = issueRepository;
    }

    public IContragentRepository ContragentRepository { get; }
    public IOperationRepository OperationRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IIssueRepository IssueRepository { get; }
    public IManufacturingProcessRepository ManufacturingProcessRepository { get; }
    public IStepRepository StepRepository { get; }
    public ITechCardItemRepository TechCardItemRepository { get; }
    public ITechCardRepository TechCardRepository { get; }
    public ITechCardStepRepositrory TechCardStepRepository { get; }
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
            MarkAuditEntities(auditableEntries);
        
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void MarkAuditEntities(EntityEntry<IAuditableEntity>[] auditableEntries)
    {
        var userId = _identityProvider.GetUserId() ?? 
                     throw new InvalidOperationException("Пользователь, модифицирующий сущности обязан быть авторизованным");
        
        foreach (var entry in auditableEntries)
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = _timeProvider.GetUtcNow();
                    entry.Entity.CreatedById = userId;
                    entry.Entity.UpdatedAt = _timeProvider.GetUtcNow();
                    entry.Entity.UpdatedById = userId;
                    entry.Entity.DeletedAt = null;
                    entry.Entity.DeletedById = null;
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
    }
}