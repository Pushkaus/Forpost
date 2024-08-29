using Forpost.Application.Contracts.Issues;
using Forpost.Application.ProductCreating.Issues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;
[Route("api/v1/issues")]
public sealed class IssueController: ApiController
{
    [HttpGet("{manufacturingProcessId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<IssueFromManufacturingProcess>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<IssueFromManufacturingProcess>> 
        GetIssuesFromManufacturingProcess(Guid manufacturingProcessId, CancellationToken cancellationToken) 
        => await Mediator.Send(new IssuesFromManufacturingProcessQuery(manufacturingProcessId), cancellationToken);

    [HttpPut("{id:guid}/launch")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Launch(Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new LaunchIssueCommand(id), cancellationToken);
        return Ok();
    }
    
    [HttpPut("{id:guid}/complete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new CompletedIssueCommand(id), cancellationToken);
        return Ok();
    }
}