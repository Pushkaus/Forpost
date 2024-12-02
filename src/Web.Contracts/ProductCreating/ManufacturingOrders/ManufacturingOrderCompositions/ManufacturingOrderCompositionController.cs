using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;
using Forpost.Features.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

[Route("api/v1/manufacturing-order-composition")]
public sealed class ManufacturingOrderCompositionController : ApiController
{
    /// <summary>
    /// Добавить продукт в заказ на производство
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddAsync([FromBody] AddManufacturingOrderCompositionRequest request,
        CancellationToken cancellationToken)
    {
        var command =
            new AddManufacturingOrderCompositionCommand(request.ManufacturingOrderId, request.ProductId,
                request.Quantity);
        var result = await Sender.Send(command, cancellationToken);
        return CreatedAtRoute(null, result);
    }
    /// <summary>
    /// Изменить количество продукта в составе заказа на производство
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangeQuantityAsync(Guid id,
        [FromBody] ChangeQuantityManufacturingOrderCompositionRequest request,
        CancellationToken cancellationToken)
    {
        var command = new ChangeQuantityManufacturingOrderCompositionCommand(id, request.Quantity);
        await Sender.Send(command, cancellationToken);
        return NoContent();
    }
    /// <summary>
    /// Удалить продукт из состава заказа на производство
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteManufacturingOrderCompositionCommand(id);
        await Sender.Send(command, cancellationToken);
        return NoContent();
    }
    /// <summary>
    /// Получить состав заказа в производство
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ManufacturingOrderCompositionModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetByIdManufacturingOrderCompositionQuery(id), cancellationToken);
        return Ok(result);
    }
}