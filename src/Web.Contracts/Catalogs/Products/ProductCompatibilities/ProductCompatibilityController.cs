using Forpost.Application.Contracts.Catalogs.Products.ProductCompatibilities;
using Forpost.Domain.Catalogs.Products.ProductCompatibilities;
using Forpost.Features.Catalogs.Products.ProductCompatibilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Products.ProductCompatibilities;

[Route("api/v1/product-compatibilities")]
public sealed class ProductCompatibilityController : ApiController
{
    /// <summary>
    /// Добавить совместимость для продукта
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> AddProductCompatibility(
        [FromBody] ProductCompatibilityRequest request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new AddProductCompabilityCommand(request.ProductId, request.ParentProductId),
            cancellationToken);
        return CreatedAtRoute("", result);
    }
    /// <summary>
    /// Получить список совместимых продуктов
    /// </summary>
    [HttpGet("{productId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductCompatibilityModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductCompatibilityByProductId(Guid productId,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllCompatibilitiesByProductIdQuery(productId), cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// Удаление позиции 
    /// </summary>
    [HttpDelete("{productCompabilityId:guid}")]
    public async Task<IActionResult> DeleteProductCompabilityById(Guid productCompabilityId,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteProductCompatibilityByIdCommand(productCompabilityId), cancellationToken);
        return NoContent();
    }
}