using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<IList<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Product>> GetAllProducts(CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllProducts(cancellationToken);
        return result;
    }

    public async Task<IActionResult> CreateProduct(Guid userId, string productName, string? version, decimal cost,
        CancellationToken cancellationToken)
    {
        var result = await _productRepository.CreateProduct(userId, productName, version, cost, cancellationToken);
        return new OkObjectResult(result);
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