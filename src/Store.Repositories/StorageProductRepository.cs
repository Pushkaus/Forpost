using System.Diagnostics;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Web.Contracts;
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
    
    public async Task<IList<ProductOnStorage>> GetAllProductsOnStorage()
    {
        var storageProducts = await _db.StorageProducts
            .Include(sp => sp.Product)
            .Include(sp => sp.Storage)
            .ToListAsync();

        var result = storageProducts.Select(sp => new ProductOnStorage
        {
            ProductName = sp.Product.Name,
            StorageName = sp.Storage.Name,
            Quantity = sp.Quantity,
            UnitOfMeasure = sp.UnitOfMeasure
        }).ToList();

        return result;
    }
    public async Task<string> AddProductOnStorage(string productName, string storageName, decimal quantity, string unitOfMeasure)
    {
        var product = await _db.Products.FirstOrDefaultAsync(f => f.Name == productName);
        if (product == null)
        {
            throw new InvalidOperationException($"Продукт с таким наименованием: {productName} не найден.");
        }

        // Получение склада
        var storage = await _db.Storages.FirstOrDefaultAsync(f => f.Name == storageName);
        if (storage == null)
        {
            throw new InvalidOperationException($"Склад с таким наименованием {storageName} не найден.");
        }

        // Создание новой записи о продукте на складе
        var productOnStorage = new StorageProduct(product.Id, storage.Id, unitOfMeasure, quantity);
        await _db.StorageProducts.AddAsync(productOnStorage);
        await _db.SaveChangesAsync();

        return $"Продукт {product.Name} в количестве {quantity} {unitOfMeasure} успешно добавлен на склад {storage.Name}";
    }
}