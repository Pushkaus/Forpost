using System.Collections;
using System.Security.Claims;
using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductOperations;
[ApiController]
[Route("api/v1/product-operation")]
public class ProductOperationController: ControllerBase
{
    private readonly IProductOperationService _productOperationService;

    public ProductOperationController(IProductOperationService productOperationService)
    {
        _productOperationService = productOperationService;
    }
    [HttpPut]
    public async Task<string> AddOperationAsync(string productName, string name, string? description,
        decimal? operationTime,
        decimal? cost)
    {
        var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var userId = Guid.Parse(user);
        var result = await _productOperationService.AddOperationAsync(userId, productName, name, description, operationTime, cost);
        return result;
    }
    [HttpGet]
    public async Task<IEnumerable<ProductOperation>> GetAllOperationOnProduct(string productName)
    {
        var result = await _productOperationService.GetAllOperationOnProduct(productName);
        return result;
    }
}