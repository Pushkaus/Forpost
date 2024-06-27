using Forpost.Business.Abstract.Services;
using Forpost.Store.Repositories.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Products;
[ApiController]
[Route("api/v1/products")]

public class ProductController: ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpPut("create-product")]
    public async Task<IActionResult> CreateProduct(Guid userId, string productName, string? version, decimal cost,
        CancellationToken cancellationToken)
    {
        var result = await _productService.CreateProduct(userId, productName, version, cost, cancellationToken);
        return new OkObjectResult(result);
    }
}