using Forpost.Application.Contracts.StorageManagment;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class StorageProductReadRepository : IStorageProductReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public StorageProductReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(IReadOnlyCollection<StorageProductModel> Products, int TotalCount)> GetProductsOnStorage(
        Guid storageId, int skip, int limit, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.StorageProducts.Where(p => p.StorageId == storageId)
            .CountAsync(cancellationToken);
        
        var products = await _dbContext.StorageProducts.Where(p => p.StorageId == storageId)
            .Join(_dbContext.Products, p => p.ProductId, p => p.Id, (s, p) => new StorageProductModel
            {
                ProductName = p.Name,
                Quantity = s.Quantity,
                ProductId = s.ProductId,
                StorageId = s.StorageId,
            }).ToListAsync(cancellationToken);
        
        return (products, totalCount);
    }
}