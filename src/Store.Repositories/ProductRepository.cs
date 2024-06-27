using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

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

    public Task<IActionResult> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> DeleteProduct(Guid deleteProductId)
    {
        throw new NotImplementedException();
    }
}