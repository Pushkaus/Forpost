using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageProductRepository
{
    public Task<string> AddProductOnStorage(string productName, string storageName, decimal quantity, string unitOfMeasure);
}