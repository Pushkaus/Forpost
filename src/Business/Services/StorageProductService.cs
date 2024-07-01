using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Web.Contracts;

namespace Forpost.Business.Services;

public sealed class StorageProductService: IStorageProductService
{
    private readonly IStorageProductRepository _storageProductRepository;

    public StorageProductService(IStorageProductRepository storageProductRepository)
    {
        _storageProductRepository = storageProductRepository;
    }
    public async Task<string> AddProductOnStorage(string productName, string storageName, decimal quantity, string unitOfMeasure)
    {
        var result = await _storageProductRepository.AddProductOnStorage(productName, storageName, quantity, unitOfMeasure);
        return result;
    }

    public async Task<IList<ProductOnStorage>> GetAllProductsOnStorage()
    {
        var result = await _storageProductRepository.GetAllProductsOnStorage();
        return result;
    }
}