using Forpost.Domain.Catalogs.Steps;
using Forpost.Features.Catalogs.Steps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Steps;
[Route("v1/api/steps")]
public sealed class StepController: ApiController
{

    /// <summary>
    /// Получение этапа по Id 
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Step), StatusCodes.Status200OK)]
    public async Task<Step?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await Mediator.Send(new GetStepByIdQuery(id), cancellationToken);

    /// <summary>
    /// Получение всех этапов
    /// </summary>
    /// <param name="cancellationToken"></param>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Step>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<Step>> GetAllAsync(CancellationToken cancellationToken) 
        => await Mediator.Send(new GetAllStepsQuery(), cancellationToken);

    /// <summary>
    /// Создание этапа
    /// </summary>
    /// <param name="step"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync([FromBody] StepCreateRequest step, CancellationToken cancellationToken) 
        => await Mediator.Send(new AddStepCommand
        {
            TechCardId = step.TechCardId,
            OperationId = step.OperationId,
            Description = step.Description,
            Duration = step.Duration,
            Cost = step.Cost,
            UnitOfMeasure = step.UnitOfMeasure,
        }, cancellationToken);
    
    /// <summary>
    /// Удаление этапа
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        //TODO;
    }
}