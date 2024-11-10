using Forpost.Domain.Catalogs.TechCardSteps;
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
    [ProducesResponseType(typeof(IReadOnlyCollection<TechCardStep>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<TechCardStep>> GetStepsByTechCardIdAsync(Guid techCardId,
        CancellationToken cancellationToken) =>
        await Sender.Send(new GetTechCardStepByIdQuery(techCardId), cancellationToken);

    /// <summary>
    /// Добавление этапа в техкарту
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardStepRequest model, CancellationToken cancellationToken)
    {
        var techCardStepId = await Sender.Send(
            new TechCardStepCreateCommand(model.TechCardId, model.StepId, model.Number), cancellationToken);
        return techCardStepId;
    }

    /// <summary>
    /// Обновление этапа в техкарте
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TechCardStepRequest model,
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