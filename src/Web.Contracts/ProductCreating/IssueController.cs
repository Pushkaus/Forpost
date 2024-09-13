using Forpost.Application.Contracts.Issues;
using Forpost.Application.Contracts.ProductCreating.Issues;
using Forpost.Features.ProductCreating.Issues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;
[Route("api/v1/issues")]
public sealed class IssueController: ApiController
{
    /// <summary>
    /// Получение всех задач производственного процесса
    /// </summary>
    [HttpGet("{manufacturingProcessId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<IssueFromManufacturingProcess>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<IssueFromManufacturingProcess>> 
        GetIssuesFromManufacturingProcess(Guid manufacturingProcessId, CancellationToken cancellationToken) 
        => await Sender.Send(new IssuesFromManufacturingProcessQuery(manufacturingProcessId), cancellationToken);

    /// <summary>
    /// Запуск задачи
    /// </summary>
    [HttpPut("{id:guid}/launch")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Launch(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new LaunchIssueCommand(id), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Назначение исполнителя задачи
    /// </summary>
    [HttpPut("{issueId:guid}/assign-executor")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AssignExecutorAsync(Guid issueId, Guid executorId, CancellationToken cancellationToken)
    {
        await Sender.Send(new AssignExecutorCommand(issueId, executorId), cancellationToken);
        return Ok();
    }
    /// <summary>
    /// Завершение задачи
    /// </summary>
    [HttpPut("{id:guid}/close")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Close(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new CloseIssueCommand(id), cancellationToken);
        return Ok();
    }
    
}