using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.StorageProduct;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageProductRepository : IRepository<StorageProductEntity>
{
    public Task<IReadOnlyList<ProductsOnStorage>> GetAllByStorageIdAsync(Guid storageId, CancellationToken cancellationToken);
    public Task<StorageProductEntity?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
}