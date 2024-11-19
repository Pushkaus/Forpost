using Forpost.Application.Contracts.StorageManagement;
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ScanBarcode([FromBody] ScanBarcodeRequest request,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(
            new ScanBarcodeProductOnStorageCommand(request.StorageId, request.ProductId, request.Barcode, request.Quantity),
            cancellationToken);
        return Ok(result);
    }
}