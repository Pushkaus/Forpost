using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Features.Catalogs.TechCardSteps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.TechCardSteps;

[Route("api/v1/tech-card-step")]
public sealed class TechCardStepController: ApiController
{
    /// <summary>
    /// Получение всех этапов по Id тех.карты
    /// </summary>
    /// <param name="techCardId"></param>
    [HttpGet("{techCardId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<TechCardStep>),StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<TechCardStep>> GetStepsByTechCardIdAsync(Guid techCardId,
        CancellationToken cancellationToken) =>
        await Sender.Send(new GetTechCardStepByIdQuery(techCardId), cancellationToken);

    /// <summary>
    /// Добавление этапа в тех.карту
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardStepRequest model, CancellationToken cancellationToken)
    {
        var techCardStepId = await Sender.Send(
            new TechCardStepCreateCommand(model.TechCardId, model.StepId, model.Number),
            cancellationToken);
        return techCardStepId;
    }
    /// <summary>
    /// Удаление этапа
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
       //TODO;
    }
}