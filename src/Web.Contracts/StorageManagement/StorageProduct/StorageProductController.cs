using Forpost.Application.Contracts.StorageManagment;
using Forpost.Features.StorageManagement;
using Forpost.Features.StorageManagement.StorageProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.StorageManagement.StorageProduct;

[Route("api/v1/storage-products")]
public sealed class StorageProductController : ApiController
{
    /// <summary>
    /// Получить список всех продуктов на складе
    /// </summary>
    /// <returns></returns>
    [HttpGet("{storageId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<StorageProductModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProductsAsync(Guid storageId, CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100)
    {
        var result = await Sender.Send(new GetProductsOnStorageQuery(storageId, skip, limit), cancellationToken);
        return Ok(new { Products = result.Products, TotalCount = result.TotalCount });
    }

    /// <summary>
    /// Добавить продукт на склад
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        CreateAsync([FromBody] StorageProductCreateRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(new AddProducOnStorageCommand(request.StorageId, request.ProductId, request.Quantity),
            cancellationToken);
        return Ok();
    }
    /// <summary>
    /// Сканирование продукта на складе
    /// </summary>
    [HttpPost("scan-barcode")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] // Добавлен статус 404
    public async Task<IActionResult> ScanBarcode([FromBody] ScanBarcodeRequest request,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new ScanBarcodeCommand(request.StorageId, request.Barcode), cancellationToken);
    
        if (result) 
        {
            return Ok(); // Продукт найден и обновлен/создан
        }
        else 
        {
            return NotFound(new { message = "Штрихкод не найден. Необходимо создать новый продукт." }); 
        }
    }
}