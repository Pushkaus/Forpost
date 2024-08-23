using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Forpost.Store.Repositories.Abstract;

/// <summary>
/// Единица работы с БД, содержит в себе все репозитории и необходимые операции для работы с БД
/// </summary>
public interface IDbUnitOfWork
{
    public IContragentRepository ContragentRepository { get; }
    
    public IOperationRepository OperationRepository { get; }
    
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
    public IManufacturingProcessRepository ManufacturingProcessRepository { get; }
    public IIssueRepository IssueRepository { get; }
    /// <summary>
    /// Начать транзакцию на уровне БД
    /// </summary>
    /// <returns></returns>
    public IDbContextTransaction BeginTransaction();
    
    /// <summary>
    /// Сохранить изменения
    /// </summary>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}