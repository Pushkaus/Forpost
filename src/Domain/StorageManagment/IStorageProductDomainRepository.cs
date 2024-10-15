using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.StorageManagment;

public interface IStorageProductDomainRepository : IDomainRepository<StorageProduct>
{
    public Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
}