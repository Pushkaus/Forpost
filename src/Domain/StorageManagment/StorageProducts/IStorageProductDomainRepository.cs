using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.StorageManagment.StorageProducts;

namespace Forpost.Domain.StorageManagment;

public interface IStorageProductDomainRepository : IDomainRepository<StorageProduct>
{
    public Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);

    public Task<StorageProduct?> GetByProductIdAndStorageIdAsync(Guid productId, Guid storageId,
        CancellationToken cancellationToken);
}