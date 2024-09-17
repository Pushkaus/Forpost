using Forpost.Features.ProductCreating.ManufacturingProcesses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ManufacturingProcessResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken, int skip = 0, int take = 100)
    {
        var result = await Sender.Send(new GetAllManufacturingProcessesQuery(skip, take), cancellationToken);
        return Ok(new
        {
            ManufacturingProcesses = result.ManufacturingProcesses,
            TotalCount = result.TotalCount,
        });
    }
}