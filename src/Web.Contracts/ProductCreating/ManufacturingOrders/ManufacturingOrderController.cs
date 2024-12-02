using Forpost.Application.Contracts;
using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders;
using Forpost.Features.ProductCreating.ManufacturingOrders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating.ManufacturingOrders;

[Route("api/v1/manufacturing-order")]
public sealed class ManufacturingOrderController : ApiController
{
    /// <summary>
    /// Получить все заказы в производство
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(EntityPagedResult<ManufacturingOrderModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync([FromQuery] ManufacturingOrderFilter filter,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllManufacturingOrderQuery(filter), cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// Создать заказ в производство
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateManufacturingOrderRequest request,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new CreateManufacturingOrderCommand(request.InvoiceId), cancellationToken);
        return CreatedAtRoute(null, result);
    }
    /// <summary>
    /// Добавить комментарий к заказу в производство
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangeCommentAsync(Guid id,
        [FromBody] ChangeCommentManufacturingOrderRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(new ChangeCommentManufacturingOrderCommand(id, request.Comment), cancellationToken);
        return NoContent();
    }
    /// <summary>
    /// Получить заказ в производство по ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ManufacturingOrderModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetByIdManufacturingOrderQuery(id), cancellationToken);
        if (result == null) return NotFound();
        return Ok(result);
    }
}