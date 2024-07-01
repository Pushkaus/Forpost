using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ForpostContextPostgres _db;

    public ProductRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public Task<IList<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Product>> GetAllProducts(CancellationToken cancellationToken)
    {
        try
        {
            var products = await _db.Products.ToListAsync(cancellationToken);
            return products;
        }
        catch (Exception ex)
        {
            throw new Exception($"Произошла ошибка при получении списка продуков: {ex.Message}");
        }
    }

    public async Task<IActionResult> CreateProduct(Guid userId, string productName, string? version, decimal cost, CancellationToken cancellationToken)
    {
        try
        {
            var product = new Product(productName, cost, userId, userId, version);
            
            await _db.Products.AddAsync(product, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return new OkResult();
        }
        catch (Exception ex)
        {
            throw new Exception($"Произошла ошибка при добавлении продукта: {ex.Message}");
        }
    }

    public async Task<string> UpdateProduct(Guid userId, string productName, string newProductName, string? version, decimal cost,
        CancellationToken cancellationToken)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Name == productName, cancellationToken);
        product.Name = newProductName;
        product.Version = version;
        product.Cost = cost;
        await _db.SaveChangesAsync(cancellationToken);
        return $"Продукт {productName} успешно обновлен";
    }

    public Task<IActionResult> DeleteProduct(Guid deleteProductId)
    {
        throw new NotImplementedException();
    }
}