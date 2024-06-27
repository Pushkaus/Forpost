using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageProductRepository
{
    public Task<IActionResult> AddProductOnStorage(Guid productId, Guid storageId, decimal quantity, string unitOfMeasure);
}