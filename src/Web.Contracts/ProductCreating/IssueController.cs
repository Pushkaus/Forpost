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
    [HttpGet("manufacturing-process/{manufacturingProcessId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<IssueFromManufacturingProcessModel>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<IssueFromManufacturingProcessModel>> 
        GetIssuesFromManufacturingProcess(Guid manufacturingProcessId, CancellationToken cancellationToken) 
        => await Sender.Send(new IssuesFromManufacturingProcessQuery(manufacturingProcessId), cancellationToken);

    /// <summary>
    /// Получение задач для исполнителя
    /// </summary>
    [HttpGet("for-executor")]
    [ProducesResponseType(typeof(IReadOnlyCollection<IssueModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetIssuesForExecutor(
        CancellationToken cancellationToken, int skip = 0, int limit = 10)
    {
        var userId = IdentityProvider.GetUserId();
        var result = await Sender.Send(new GetIssuesByExecutorIdQuery(userId.Value, skip, limit), cancellationToken);
        return Ok(new
        {
            Issues = result.Issues,
            TotalCount = result.TotalCount
        });
    } 
    /// <summary>
    /// Получение задач для исполнителя
    /// </summary>
    [HttpGet("for-responsible")]
    [ProducesResponseType(typeof(IReadOnlyCollection<IssueModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetIssuesForResponsible(
        CancellationToken cancellationToken, int skip = 0, int limit = 10)
    {
        var userId = IdentityProvider.GetUserId();
        var result = await Sender.Send(new GetIssuesByResponsibleIdQuery(userId.Value, skip, limit), cancellationToken);
        return Ok(new
        {
            Issues = result.Issues,
            TotalCount = result.TotalCount
        });
    }
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
    /// <summary>
    /// Получение задачи по ID
    /// </summary>
    [ProducesResponseType(typeof(IssueModel), StatusCodes.Status200OK)]
    [HttpGet("{issueId}")]
    public async Task<IssueModel> GetById(Guid issueId, CancellationToken cancellationToken) 
        => await Sender.Send(new GetByIdQuery(issueId), cancellationToken);
}