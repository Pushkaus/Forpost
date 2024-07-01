using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class SubProductRepository: ISubProductRepository
{
    private readonly ForpostContextPostgres _db;

    public SubProductRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public async Task<string> AddSubProduct(string parentName, string daughterName, string unitOfMeasure, decimal quantity)
    {
        try
        {
            var parent = await _db.Products.FirstOrDefaultAsync(entity => entity.Name == parentName);
            var daughter = await _db.Products.FirstOrDefaultAsync(entity => entity.Name == daughterName);
            var subProduct = new SubProduct()
            {
                ParentId = parent.Id,
                DaughterId = daughter.Id,
                UnitOfMeasure = unitOfMeasure,
                Quantity = quantity
            };
            await _db.SubProducts.AddAsync(subProduct);
            await _db.SaveChangesAsync();
            return "СубПродукт успешно добавлен";
        }
        catch (Exception ex)
        {
            return $"Возникла ошибка: {ex} при добавлении СубПродукта";
        }
    }
}