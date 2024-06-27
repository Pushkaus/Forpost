using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IProductRepository
{
    public Task<IList<Product>> GetProducts();

    public Task<IActionResult> CreateProduct(Guid userId, string productName, string? version, decimal cost,
        CancellationToken cancellationToken);

    public Task<IActionResult> UpdateProduct(Product product);
    public Task<IActionResult> DeleteProduct(Guid deleteProductId);
}