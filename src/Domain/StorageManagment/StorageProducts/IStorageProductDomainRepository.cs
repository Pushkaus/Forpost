using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.StorageManagment.StorageProducts;

public interface IStorageProductDomainRepository : IDomainRepository<StorageProduct>
{
    public Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);

    public Task<StorageProduct?> GetByProductIdAndStorageIdAsync(Guid productId, Guid storageId,
        CancellationToken cancellationToken);
}