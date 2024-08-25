using Forpost.Common.DataAccess;

namespace Forpost.Domain.Sortout;

public interface IStorageProductRepository : IRepository<StorageProduct>
{
    public Task<IReadOnlyList<StorageProduct>> GetAllByStorageIdAsync(Guid storageId, CancellationToken cancellationToken);
    public Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
}