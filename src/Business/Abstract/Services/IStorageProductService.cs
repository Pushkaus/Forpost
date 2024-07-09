using Forpost.Business.Models.StorageProduct;
using Forpost.Store.Entities;
using Forpost.Web.Contracts;

namespace Forpost.Business.Abstract.Services;

public interface IStorageProductService: IBusinessService
{
    public Task Add(StorageProductCreateModel model);
    public Task<IReadOnlyList<StorageProductModel>> GetAllProducts(Guid id);
}