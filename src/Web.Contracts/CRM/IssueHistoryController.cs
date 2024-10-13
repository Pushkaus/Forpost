using Forpost.Application.Contracts.CRM.IssueHistory;
using Forpost.Features.CRM.IssueHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.CRM;

[Route("api/v1/issue-history")]
public sealed class IssueHistoryController : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<IssueHistoryModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] IssueHistoryRequest request, CancellationToken cancellationToken)
    {
        var filter = Mapper.Map<IssueHistoryFilter>(request);
        var result = await Sender.Send(new GetAllQuery(filter), cancellationToken);
        return Ok(new { result.Issues, result.TotalCount});
    }
}