using Forpost.Common.DataAccess;

namespace Forpost.Domain.SortOut;

public interface IStorageProductRepository : IRepository<StorageProduct>
{
    public Task<IReadOnlyList<StorageProduct>> GetAllByStorageIdAsync(Guid storageId, CancellationToken cancellationToken);
    public Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
}