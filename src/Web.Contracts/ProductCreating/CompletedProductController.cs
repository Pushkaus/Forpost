using Forpost.Features.ProductCreating.CompletedProducts;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;
[Route("api/v1/completed-products")]
public sealed class CompletedProductController: ApiController
{
    /// <summary>
    /// Список всех готовых продуктов на складе
    /// </summary>
    [HttpGet("on-storage")]
    public async Task<IActionResult> GetAllOnStorage(CancellationToken cancellationToken, int skip = 0, int limit = 10)
    {
        var result = await Sender.Send(new GetAllOnStorageQuery(skip, limit), cancellationToken);
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
    public async Task<IActionResult> GetAllOnStorageByProductId(Guid productId, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllByProductIdQuery(productId), cancellationToken));
    }
}