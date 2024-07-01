using Forpost.Store.Entities;
using Forpost.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageProductRepository
{
    public Task<IList<ProductOnStorage>> GetAllProductsOnStorage();
    public Task<string> AddProductOnStorage(string productName, string storageName, decimal quantity, string unitOfMeasure);
}