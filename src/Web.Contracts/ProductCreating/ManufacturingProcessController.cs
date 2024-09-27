using Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;
using Forpost.Features.ProductCreating.ManufacturingProcesses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Forpost.Web.Contracts.ProductCreating;

[Route("api/v1/manufacturingProcesses")]
public sealed class ManufacturingProcessController : ApiController
{
    /// <summary>
    /// Планирование производственного процесса
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Schedule(ScheduledManufacturingProcessCommand command,
        CancellationToken cancellationToken)
    {
        var manufacturingProcessId = await Sender.Send(new ScheduledManufacturingProcessCommand
        {
            TechnologicalCardId = command.TechnologicalCardId,
            BatchNumber = command.BatchNumber,
            TargetQuantity = command.TargetQuantity,
            StartTime = command.StartTime,
            Issues = command.Issues
        }, cancellationToken);
        return Ok(manufacturingProcessId);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ManufacturingProcessWithDetailsModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetManufacturingProcessByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Запуск производственного процесса
    /// </summary>
    [HttpPut("{id}/launch")]
    public async Task<IActionResult> Launch(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new LaunchManufacturingProcessCommand(id), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Завершение производственного процесса
    /// </summary>
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new CompletionManufacturingProcessCommand(id), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить все производственные процессы
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ManufacturingProcessResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100,
        [FromQuery] string? filterExpression = null, [FromQuery] string?[]? filterValues = null)
    {
        var result =
            await Sender.Send(new GetAllManufacturingProcessesQuery(filterExpression, filterValues, skip, limit),
                cancellationToken);
        return Ok(new
        {
            ManufacturingProcesses =
                Mapper.Map<IReadOnlyCollection<ManufacturingProcessResponse>>(result.ManufacturingProcesses),
            TotalCount = result.TotalCount,
        });
    }
}