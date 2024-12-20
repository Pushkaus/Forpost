using Forpost.Application.Contracts.Catalogs.TechCards.Steps;
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
    [ProducesResponseType(typeof(StepModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<Step>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var step = await Sender.Send(new GetStepByIdQuery(id), cancellationToken);
        return Ok(step);
    }

    /// <summary>
    /// Получение всех этапов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Step>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync([FromQuery] StepFilter filter, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllStepsQuery(filter),
            cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Создание этапа
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] StepCreateRequest request, CancellationToken cancellationToken)
    {
        var stepId = await Sender.Send(new AddStepCommand
        {
            OperationId = request.OperationId,
            Description = request.Description,
            Duration = request.Duration,
        }, cancellationToken);

        return CreatedAtAction("", new { id = stepId }, stepId);
    }

    /// <summary>
    /// Обновление этапа
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] StepCreateRequest step, CancellationToken cancellationToken)
    {
        await Sender.Send(new UpdateStepCommand(
            Id: id,
            OperationId: step.OperationId,
            Description: step.Description,
            Duration: step.Duration
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