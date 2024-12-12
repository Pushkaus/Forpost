using Forpost.Application.Contracts.Catalogs.Products.ProductAttributes;
using Forpost.Features.Catalogs.Products.ProductAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Products.ProductAttributes;

[Route("api/v1/product-attributes")]
public sealed class ProductAttributeController : ApiController
{
    /// <summary>
    /// Добавление атрибута к продукту
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProductAttribute([FromBody] ProductAttributeRequest request,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new CreateProductAttributeCommand(request.ProductId, request.AttributeId),
            cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// Обновление значений атрибута
    /// </summary>
    [HttpPut("{productAttributeId:guid}/values")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddProductAttributeValues(Guid productAttributeId,
        [FromBody] ProductAttributeValuesRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new UpdateProductAttributeValuesCommand(productAttributeId, request.Values), cancellationToken);
        return NoContent();
    }
    /// <summary>
    /// Получение всех атрибутов продукта
    /// </summary>
    [HttpGet("{productId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductAttributeModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAttributesByProductId(Guid productId, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllAttributesByProductIdQuery(productId), cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// Удаление атрибута продукта
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProductAttribute(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteProductAttributeByIdCommand(id), cancellationToken);
        return NoContent();
    }
}
