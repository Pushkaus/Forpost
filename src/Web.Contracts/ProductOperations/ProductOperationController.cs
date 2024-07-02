using System.Collections;
using System.Security.Claims;
using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.ProductOperation;
using Forpost.Web.Contracts.Models.ProductOperations;
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
    public async Task<string> AddOperationAsync(AddOperationDto operation)
    {
        var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var userId = Guid.Parse(user);
        var result = await _productOperationService.AddOperationAsync(userId, operation.ProductName, operation.Name,
            operation.Description, operation.OperationTime, operation.Cost);
        return result;
    }
    [HttpGet]
    public async Task<IEnumerable<GerProductOperations>> GetAllOperationOnProduct([FromQuery] string productName)
    {
        var result = await _productOperationService.GetAllOperationOnProduct(productName);
        return result;
    }
}