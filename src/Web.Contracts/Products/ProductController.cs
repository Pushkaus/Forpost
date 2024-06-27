using System.Security.Claims;
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

    /// <summary>
    /// Получение всех продуктов
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all-products")]
    public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
    {
        var result = await _productService.GetAllProducts(cancellationToken);
        return new OkObjectResult(result);
    }
    /// <summary>
    /// Создание продукта
    /// </summary>
    [HttpPut("create-product")]
    public async Task<IActionResult> CreateProduct(string productName, string? version, decimal cost,
        CancellationToken cancellationToken)
    {
        var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var userId = Guid.Parse(user);
        Console.WriteLine(userId);
        var result = await _productService.CreateProduct(userId, productName, version, cost, cancellationToken);
        return new OkObjectResult(result);
    }
}