using BarcodeStandard;
using Forpost.Features.Catalogs.Barcodes.ProductBarcodes;
using Forpost.Features.Catalogs.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using ZXing;

namespace Forpost.Web.Contracts.Catalogs.Products;

[Route("api/v1/products")]
[Authorize]
public sealed class ProductController : ApiController
{
    /// <summary>
    /// Получение всех продуктов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof((IReadOnlyCollection<ProductResponse> Products, int TotalCount)),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<(IReadOnlyCollection<ProductResponse> Products, int TotalCount)>>
        GetAllAsync(CancellationToken cancellationToken,
            [FromQuery] int skip = 0, [FromQuery] int limit = 100,
            [FromQuery] string? filterExpression = null, [FromQuery] string?[]? filterValues = null)
    {
        var result = await Sender.Send(new GetAllProductsQuery(filterExpression, filterValues, skip, limit),
            cancellationToken);
        
        var productResponses = Mapper.Map<IReadOnlyCollection<ProductResponse>>(result.Products);
        return Ok(new
        {
            Products = productResponses,
            TotalCount = result.TotalCount
        });
    }

    /// <summary>
    /// Получение продукта по id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await Sender.Send(new GetProductByIdQuery(id), cancellationToken);
        return Ok(product);
    }

    /// <summary>
    /// Создать продукт
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        CreateAsync([FromBody] ProductCreateRequest request, CancellationToken cancellationToken)
    {
        var productId = await Sender.Send(new AddProductCommand(request.Name, request.Purchased, request.CategoryId),
            cancellationToken);
        return Ok(productId);
    }

    /// <summary>
    /// Обновление продукта по id
    /// </summary>
    /// <param name="request"></param>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        UpdateAsync([FromBody] ProductUpdateRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(new UpdateProductCommand(
            request.Id,
            request.Name,
            request.Purchased,
            request.CategoryId), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удаление продукта по id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        //TODO;
        return Ok();
    }

    /// <summary>
    /// Получение QR-продукта. Содержит JSON с Id и Name продукта.
    /// </summary>
    [HttpGet("{productId}/barcode")]
    [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBarcodePngsAsync(Guid productId, CancellationToken cancellationToken)
    {
        var productQrCode = await Sender.Send(new GetBarcodeByProductIdQuery(productId), cancellationToken);
        return File(productQrCode, "image/png");
    }

    /// <summary>
    /// Добавить штрихкод продукта.
    /// </summary>
    [HttpPost("barcode")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBarcode([FromBody] BarcodeRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new AddBarcodeProductCommand(request.ProductId, request.Barcode), cancellationToken);
        return NoContent();
    }
}