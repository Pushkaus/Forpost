using Forpost.Application.Contracts.ProductCreating.CompositionProduct;
using Forpost.Features.ProductCreating.ProductsDevelopments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;

[Route("api/v1/product-development")]
public sealed class ProductDevelopmentController : ApiController
{
    /// <summary>
    /// Получение всех продуктов в разработке
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductDevelopmentResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100,
        [FromQuery] string? filterExpression = null, [FromQuery] string?[]? filterValues = null)
    {
        var result = await Sender.Send(new GetAllDevelopmentProductsQuery(filterExpression, filterValues, skip, limit),
            cancellationToken);
        return Ok(new
        {
            Developments = Mapper.Map<IReadOnlyCollection<ProductDevelopmentResponse>>(result.Developments),
            TotalCount = result.TotalCount
        });
    }

    /// <summary>
    /// Получение всех продуктов по ID задачи
    /// </summary>
    [HttpGet("issue/{issueId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductDevelopmentResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByIssueId(Guid issueId, CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100)
    {
        var result = await Sender.Send(new GetAllByIssueIdQuery(issueId, skip, limit), cancellationToken);
        return Ok(new
        {
            Developments = Mapper.Map<IReadOnlyCollection<ProductDevelopmentResponse>>(result.ProductDevelopments),
            TotalCount = result.TotalCount
        });
    }

    /// <summary>
    /// Завершить задачу, переход на следующий этап или создание готового продукта
    /// </summary>
    [HttpPut("issues/complete/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CompleteIssue([FromBody] CompleteIssueRequest request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new CompleteIssueCommand(request.ProductDevelopmentIds), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Заполнение состава продукта
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> SetCompositionProduct([FromBody] CompositionProductRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new SetCompositionProductCommand(request.ProductDevelopmentId, request.CompletedProductsId),
            cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение состава продукта по ProductDevelopmentId 
    /// </summary>
    [HttpGet("{productDevelopmentId}/composition")]
    [ProducesResponseType(typeof(CompositionProductGroupModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompositionProduct
        (Guid productDevelopmentId, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetCompositionByIdQuery(productDevelopmentId), cancellationToken));
    }

    /// <summary>
    /// Получение состава тех.карты по ProductDevelopmentId
    /// </summary>
    [HttpGet("{productDevelopmentId}/techcard-items")]
    public async Task<IActionResult> GetTechCardItemsByProductDevelopmentId
        (Guid productDevelopmentId, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetTechCardItemsByIdQuery(productDevelopmentId), cancellationToken));
    }
}