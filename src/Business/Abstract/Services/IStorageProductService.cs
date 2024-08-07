using Forpost.Business.Models.StorageProduct;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IStorageProductService: IBusinessService
{
    public Task<Guid> Add(StorageProductCreateModel model);
    public Task<IReadOnlyList<StorageProductModel>> GetAllProducts(Guid id);
    public Task<StorageProduct?> GetById(Guid id);
    public Task Update(StorageProductCreateModel model);
    public Task WriteOff(Guid productId, int quantity);
}