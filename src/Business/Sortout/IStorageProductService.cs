using Forpost.Store.Entities;

namespace Forpost.Business.Sortout;

public interface IStorageProductService : IBusinessService
{
    public Task<Guid> AddAsync(StorageProductCreateCommand model, CancellationToken cancellationToken);
    public Task<IReadOnlyList<StorageProduct>> GetAllProductsAsync(Guid id, CancellationToken cancellationToken);
    public Task<StorageProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task UpdateAsync(StorageProductCreateCommand model, CancellationToken cancellationToken);
    public Task WriteOffAsync(Guid productId, int quantity, CancellationToken cancellationToken);
}