using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Models;

public class StorageProductRepository: IStorageProductRepository
{
    private readonly ForpostContextPostgres _db;

    public StorageProductRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public async Task<IActionResult> AddProductOnStorage(Guid productId, Guid storageId, decimal quantity, string unitOfMeasure)
    {
        return null;
    }
}