using AutoMapper;
using Forpost.Domain.SortOut;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class StorageProductDomainRepository : DomainRepository<StorageProduct>, IStorageProductDomainRepository
{
    public StorageProductDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<StorageProduct>>
        GetAllByStorageIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await DbSet
            .Join(
                DbContext.Products,
                entity => entity.ProductId,
                product => product.Id,
                (entity, product) => new { entity, product }
            )
            .Join(
                DbContext.Storages,
                combined => combined.entity.StorageId,
                storage => storage.Id,
                (combined, storage) => new StorageProduct
                {
                    ProductId = combined.entity.ProductId,
                    ProductName = combined.product.Name,
                    UnitOfMeasure = combined.entity.UnitOfMeasure,
                    Quantity = combined.entity.Quantity,
                    StorageId = combined.entity.StorageId,
                    StorageName = storage.Name
                }
            )
            .ToListAsync(cancellationToken);

        return result;
    }

    public async Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.ProductId == productId).FirstOrDefaultAsync(cancellationToken);
    }
}