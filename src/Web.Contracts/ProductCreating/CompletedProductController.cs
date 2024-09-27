using Forpost.Application.Contracts.ProductCreating.CompletedProducts;
using Forpost.Features.ProductCreating.CompletedProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;

[Route("api/v1/completed-products")]
public sealed class CompletedProductController : ApiController
{
    /// <summary>
    /// Список всех готовых продуктов на складе
    /// </summary>
    [HttpGet("on-storage")]
    public async Task<IActionResult> GetAllOnStorage(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100,
        [FromQuery] string? filterExpression = null, [FromQuery] string?[]? filterValues = null)
    {
        var result = await Sender.Send(new GetAllOnStorageQuery(filterExpression, filterValues, skip, limit),
            cancellationToken);
        return Ok(new
        {
            CompletedProducts = result.CompletedProducts,
            TotalCount = result.TotalCount
        });
    }

    /// <summary>
    /// Список готовых продуктов по ProductID (справочный ID) 
    /// </summary>
    [HttpGet("product/{productId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<CompletedProductModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOnStorageByProductId(Guid productId, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllByProductIdQuery(productId), cancellationToken));
    }
}