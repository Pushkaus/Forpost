using Forpost.Application.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;

[Route("api/v1/manufacturing-processes")]
public sealed class ManufacturingProcessController : ApiController
{
    [HttpGet]
    public async Task<IReadOnlyCollection<ManufacturingProcess>> ViewManufacturingProcessesAsync(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new ViewManufacturingProcessesQuery(), cancellationToken);
    }
    [HttpPost]
    public async Task<IActionResult> Schedule(ScheduledManufacturingProcessCommand command,
        CancellationToken cancellationToken)
    {
        var manufacturingProcessId = await Mediator.Send(command, cancellationToken);
        return Ok(manufacturingProcessId);
    }
    [HttpPut("{id:guid}/launch")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Launch(Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new LaunchManufacturingProcessCommand(id), cancellationToken);
        return Ok();
    }
    [HttpPut("{id:guid}/complete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new CompletionManufacturingProcessCommand(id), cancellationToken);
        return Ok();
    }
}