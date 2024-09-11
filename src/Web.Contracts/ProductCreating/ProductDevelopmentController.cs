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
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductDevelopment>), StatusCodes.Status200OK)]
    public async Task<(IReadOnlyCollection<ProductDevelopment>, int)> GetAllAsync(CancellationToken cancellationToken,
        [FromQuery] int skip, [FromQuery] int limit) 
        => await Sender.Send(new GetAllDevelopmentProductsQuery(skip, limit), cancellationToken);
}