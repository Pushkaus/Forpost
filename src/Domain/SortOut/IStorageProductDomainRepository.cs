using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.SortOut;

public interface IStorageProductDomainRepository : IDomainRepository<StorageProduct>
{
    public Task<IReadOnlyList<StorageProduct>> GetAllByStorageIdAsync(Guid storageId, CancellationToken cancellationToken);
    public Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
}