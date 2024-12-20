using Forpost.Domain.Catalogs.TechCards.Operations;
using Forpost.Features.Catalogs.TechCards.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Operations;

[Route("api/v1/operations")]
public sealed class OperationController : ApiController
{
    /// <summary>
    /// Добавление операции
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<Guid> AddAsync([FromBody] OperationRequest request, CancellationToken cancellationToken)
    {
        return await Sender.Send(new AddOperationCommand(request.Name, request.Description, request.OperationTypeValue),
            cancellationToken);
    }
    /// <summary>
    /// Изменить описание операции
    /// </summary>
    [HttpPut("{id}/description")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ChangeOperationDescription(Guid id, [FromBody] OperationDescriptionRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new ChangeDescriptionOperationCommand(id, request.Description), cancellationToken);
        return NoContent();
    }
    /// <summary>
    /// Удаление операции по ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteOperationAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteOperationCommand(id), cancellationToken);
        return NoContent();
    }
    /// <summary>
    /// Получить операцию по ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Operation), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOperationById(Guid id, CancellationToken cancellationToken)
    {
        var operation = await Sender.Send(new GetOperationByIdQuery(id), cancellationToken);
        return Ok(operation);
    }
    
    /// <summary>
    /// Получение всех операций
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Operation>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllOperationsQuery(), cancellationToken);
        if (!result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }
}
