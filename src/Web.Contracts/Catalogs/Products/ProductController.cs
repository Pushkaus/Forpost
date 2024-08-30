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
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductResponse>), 200)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await Mediator.Send(new GetAllProductsQuery(), cancellationToken);
        return Ok(products);
    }

    /// <summary>
    /// Получение продукта по id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await Mediator.Send(new GetProductByIdQuery(id), cancellationToken);
        return Ok(product);
    }

    /// <summary>
    /// Создать продукт
    /// </summary>
    /// <param name="request"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        CreateAsync([FromBody] ProductCreateRequest request, CancellationToken cancellationToken)
    {
        var productId = await Mediator.Send(new AddProductCommand(request.Name, request.Version), cancellationToken);
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
        await Mediator.Send(new UpdateProductCommand(
            request.Id,
            request.Name,
            request.Version), cancellationToken);
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
}