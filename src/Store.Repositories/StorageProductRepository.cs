using System.Diagnostics;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Models;

public class StorageProductRepository: IStorageProductRepository
{
    private readonly ForpostContextPostgres _db;

    public StorageProductRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public async Task<string> AddProductOnStorage(string productName, string storageName, decimal quantity, string unitOfMeasure)
    {
        var product = await _db.Products.FirstOrDefaultAsync(f => f.Name == productName);
        if (product == null)
        {
            throw new InvalidOperationException($"Product with name {productName} does not exist.");
        }

        // Получение склада
        var storage = await _db.Storages.FirstOrDefaultAsync(f => f.Name == storageName);
        if (storage == null)
        {
            throw new InvalidOperationException($"Storage with name {storageName} does not exist.");
        }

        // Создание новой записи о продукте на складе
        var productOnStorage = new StorageProduct(product.Id, storage.Id, unitOfMeasure, quantity);
        await _db.StorageProducts.AddAsync(productOnStorage);
        await _db.SaveChangesAsync();

        return $"Продукт {product.Name} в количестве {quantity} {unitOfMeasure} успешно добавлен на склад {storage.Name}";
    }
}