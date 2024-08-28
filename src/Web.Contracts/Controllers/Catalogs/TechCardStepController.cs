using Forpost.Application.Catalogs.TechCardSteps;
using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Web.Contracts.Models.TechCardSteps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Catalogs;

[Route("api/v1/tech-card-step")]
public sealed class TechCardStepController: ApiController
{
    /// <summary>
    /// Получение всех этапов по Id тех.карты
    /// </summary>
    /// <param name="techCardId"></param>
    [HttpGet("{techCardId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<StepsInTechCardResponse>),StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<TechCardStep>> GetStepsByTechCardIdAsync(Guid techCardId,
        CancellationToken cancellationToken) =>
        await Mediator.Send(new GetTechCardStepByIdQuery(techCardId), cancellationToken);

    /// <summary>
    /// Добавление этапа в тех.карту
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardStepRequest model, CancellationToken cancellationToken)
    {
        var techCardStepId = await Mediator.Send(new 
            TechCardStepCreateCommand(model.TechCardId, model.StepId, model.Number),
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