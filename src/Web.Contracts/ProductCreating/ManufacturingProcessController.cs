using Forpost.Features.ProductCreating.ManufacturingProcesses;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;

[Route("api/v1/manufacturingProcesses")]
public sealed class ManufacturingProcessController : ApiController
{
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
    [HttpPut("launch/{id}")]
    public async Task<IActionResult> Launch(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new LaunchManufacturingProcessCommand(id), cancellationToken);
        return Ok();
    }
    [HttpPut("complete/{id}")]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new CompletionManufacturingProcessCommand(id), cancellationToken);
        return Ok();
    }
}