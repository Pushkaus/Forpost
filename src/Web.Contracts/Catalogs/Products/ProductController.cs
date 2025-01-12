using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.Products;
using Forpost.Features.Catalogs.Barcodes.ProductBarcodes;
using Forpost.Features.Catalogs.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Products;

[Route("api/v1/products")]
[Authorize]
public sealed class ProductController : ApiController
{
    /// <summary>
    /// Получение всех продуктов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(EntityPagedResult<ProductModel>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult>
        GetAllAsync([FromQuery] ProductFilter filter, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllProductsQuery(filter),
            cancellationToken));
    }

    /// <summary>
    /// Получение продукта по id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductModel), StatusCodes.Status200OK)]
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
    /// Удаление продукта
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteProductByIdCommand(id), cancellationToken);
        return NoContent();
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