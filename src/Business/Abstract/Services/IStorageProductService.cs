using Forpost.Business.Models.StorageProduct;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IStorageProductService : IBusinessService
{
    public Task<Guid> AddAsync(StorageProductCreateModel model, CancellationToken cancellationToken);
    public Task<IReadOnlyList<StorageProductModel>> GetAllProductsAsync(Guid id, CancellationToken cancellationToken);
    public Task<StorageProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task UpdateAsync(StorageProductCreateModel model, CancellationToken cancellationToken);
    public Task WriteOffAsync(Guid productId, int quantity, CancellationToken cancellationToken);
}