using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardOperations;
using Forpost.Features.Catalogs.TechCards.TechCardOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.TechCardOperations;

[Route("api/v1/tech-card-operation")]
public sealed class TechCardOperationController : ApiController
{
    /// <summary>
    /// Получение всех этапов по Id тех.карты
    /// </summary>
    [HttpGet("{techCardId}")]
    [ProducesResponseType(typeof(EntityPagedResult<TechCardOperationModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOperationsByTechCardIdAsync(Guid techCardId, [FromQuery] TechCardOperationFilter filter,
        CancellationToken cancellationToken) =>
        Ok(await Sender.Send(new GetTechCardOperationByIdQuery(techCardId, filter), cancellationToken));

    /// <summary>
    /// Добавление этапа в техкарту
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync([FromBody] TechCardOperationRequest model, CancellationToken cancellationToken)
    {
        var techCardOperationId = await Sender.Send(
            new TechCardOperationCreateCommand(model.TechCardId, model.OperationId), cancellationToken);
        return techCardOperationId;
    }

    /// <summary>
    /// Обновление этапа в техкарте
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateTechCardOperationRequest model,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new UpdateTechCardOperationCommand(id, model.TechCardId, model.OperationId, model.Number),
            cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Удаление этапа
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteTechCardOperationCommand(id), cancellationToken);
        return NoContent();
    }
}