using Forpost.Store.Entities;
using Forpost.Web.Contracts;

namespace Forpost.Business.Abstract.Services;

public interface IStorageProductService: IBusinessService
{
    public Task<string> AddProductOnStorage(string productName, string storageName, decimal quantity, string unitOfMeasure);
    public Task<IList<ProductOnStorage>> GetAllProductsOnStorage();
}