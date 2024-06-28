using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.StorageProduct;
[ApiController]
[Route("api/v1/storage-products")]
public class StorageProductController: ControllerBase
{
    private readonly IStorageProductService _storageProductService;

    public StorageProductController(IStorageProductService storageProductService)
    {
        _storageProductService = storageProductService;
    }
   
    [HttpGet("get-all-products-on-storage")]
    public async Task<IActionResult> GetAllProductsOnStorage()
    {
        var result = await _storageProductService.GetAllProductsOnStorage();
        return Ok(result);
    }
    [HttpPut("add-product-on-storage")]
    public async Task<IActionResult> AddProductOnStorage(string productName, string storageName, decimal quantity,
        string unitOfMeasure)
    {
        var result = await _storageProductService.AddProductOnStorage(productName, storageName, quantity, unitOfMeasure);
        return Ok(result);
    }
}