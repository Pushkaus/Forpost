using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IProductService: IBusinessService
{
    public Task<IList<Product>> GetProducts();
    public Task<IList<Product>> GetAllProducts(CancellationToken cancellationToken);
    public Task<IActionResult> CreateProduct(Guid userId, string productName, string? version, decimal cost,
        CancellationToken cancellationToken);
    public Task<string> UpdateProduct(Guid userId, string productName, string newProductName, string? version, decimal cost,
        CancellationToken cancellationToken);
    public Task<IActionResult> DeleteProduct(Guid deleteProductId);
}