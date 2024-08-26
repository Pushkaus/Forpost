using Forpost.Application.ProductCreating.ManufacturingProcesses;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.ProductCreating;

[Route("api/v1/manufacturingProcesses")]
public sealed class ManufacturingProcessController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Schedule(ScheduledManufacturingProcessCommand command,
        CancellationToken cancellationToken)
    {
        var manufacturingProcessId = await Mediator.Send(command, cancellationToken);
        return Ok(manufacturingProcessId);
    }
    [HttpPut("launch/{id}")]
    public async Task<IActionResult> Launch(Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new LaunchManufacturingProcessCommand(id), cancellationToken);
        return Ok();
    }
    [HttpPut("complete/{id}")]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new CompletionManufacturingProcessCommand(id), cancellationToken);
        return Ok();
    }
}