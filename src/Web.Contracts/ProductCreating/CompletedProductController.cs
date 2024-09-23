using Forpost.Features.ProductCreating.CompletedProducts;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;
[Route("api/v1/completed-products")]
public sealed class CompletedProductController: ApiController
{
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
}