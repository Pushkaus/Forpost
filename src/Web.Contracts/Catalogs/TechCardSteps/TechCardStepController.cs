using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardSteps;
using Forpost.Domain.Catalogs.TechCards.TechCardSteps;
using Forpost.Features.Catalogs.TechCards.TechCardSteps;
using Forpost.Features.Catalogs.TechCardSteps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.TechCardSteps;

[Route("api/v1/tech-card-step")]
public sealed class TechCardStepController : ApiController
{
    /// <summary>
    /// Получение всех этапов по Id тех.карты
    /// </summary>
    [HttpGet("{techCardId}")]
    [ProducesResponseType(typeof(EntityPagedResult<TechCardStepModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStepsByTechCardIdAsync(Guid techCardId, [FromQuery] TechCardStepFilter filter,
        CancellationToken cancellationToken) =>
        Ok(await Sender.Send(new GetTechCardStepByIdQuery(techCardId, filter), cancellationToken));

    /// <summary>
    /// Добавление этапа в техкарту
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync([FromBody] TechCardStepRequest model, CancellationToken cancellationToken)
    {
        var techCardStepId = await Sender.Send(
            new TechCardStepCreateCommand(model.TechCardId, model.StepId), cancellationToken);
        return techCardStepId;
    }

    /// <summary>
    /// Обновление этапа в техкарте
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateTechCardStepRequest model,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new UpdateTechCardStepCommand(id, model.TechCardId, model.StepId, model.Number),
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
        await Sender.Send(new DeleteTechCardStepCommand(id), cancellationToken);
        return NoContent();
    }
}