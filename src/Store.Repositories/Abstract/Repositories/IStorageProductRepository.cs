using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.StorageProduct;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageProductRepository : IRepository<StorageProduct>
{
    public Task<IReadOnlyList<ProductsOnStorage>> GetAllByStorageIdAsync(Guid storageId, CancellationToken cancellationToken);
    public Task<StorageProduct?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
}