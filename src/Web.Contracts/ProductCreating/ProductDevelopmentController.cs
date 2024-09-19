using Forpost.Domain.ProductCreating.ProductDevelopment;
using Forpost.Features.ProductCreating.ProductsDevelopments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;
[Route("api/v1/product-development")]
public sealed class ProductDevelopmentController: ApiController
{
    /// <summary>
    /// Получение всех продуктов в разработке
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductDevelopmentResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100)
    {
        var result = await Sender.Send(new GetAllDevelopmentProductsQuery(skip, limit), cancellationToken);
        return Ok(new
        {
            Developments = Mapper.Map<IReadOnlyCollection<ProductDevelopmentResponse>>(result.Developments),
            TotalCount = result.TotalCount
        });
    }
}