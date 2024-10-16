using AutoMapper;
using Forpost.Domain.StorageManagment;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.StorageManagment;

internal sealed class StorageProductDomainRepository : DomainRepository<StorageProduct>, IStorageProductDomainRepository
{
    public StorageProductDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }


    public async Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.ProductId == productId).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<StorageProduct?> GetByProductIdAndStorageIdAsync(Guid productId, Guid storageId,
        CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.ProductId == productId && entity.StorageId == storageId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}