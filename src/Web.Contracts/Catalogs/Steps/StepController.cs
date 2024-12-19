using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.TechCards.Steps;
using Forpost.Features.Catalogs.TechCards.Steps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Steps;

[Route("api/v1/steps")]
public sealed class StepController : ApiController
{
    /// <summary>
    /// Получение этапа по Id 
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Step), StatusCodes.Status200OK)]
    public async Task<ActionResult<Step>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var step = await Sender.Send(new GetStepByIdQuery(id), cancellationToken);
        if (step == null)
            return NotFound();

        return Ok(step);
    }

    /// <summary>
    /// Получение всех этапов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Step>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100,
        [FromQuery] string? filterExpression = null, [FromQuery] object?[]? filterValues = null)
    {
        var result = await Sender.Send(new GetAllStepsQuery(filterExpression, filterValues, skip, limit),
            cancellationToken);

        if (result.Steps.Count == 0)
            return NoContent();

        return Ok(new
        {
            Steps = result.Steps,
            TotalCount = result.TotalCount
        });
    }

    /// <summary>
    /// Создание этапа
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] StepCreateRequest step, CancellationToken cancellationToken)
    {
        var stepId = await Sender.Send(new AddStepCommand
        {
            TechCardId = step.TechCardId,
            OperationId = step.OperationId,
            Description = step.Description,
            Duration = step.Duration,
            Cost = step.Cost,
            UnitOfMeasure = step.UnitOfMeasure,
        }, cancellationToken);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = stepId }, stepId);
    }

    /// <summary>
    /// Обновление этапа
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] StepCreateRequest step, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new UpdateStepCommand(
            StepId: id,
            TechCardId: step.TechCardId,
            OperationId: step.OperationId,
            Description: step.Description,
            Duration: step.Duration,
            Cost: step.Cost,
            UnitOfMeasure: step.UnitOfMeasure
        ), cancellationToken);
        return NoContent();
    }


    /// <summary>
    /// Удаление этапа
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteStepCommand(id), cancellationToken);

        return NoContent();
    }
}