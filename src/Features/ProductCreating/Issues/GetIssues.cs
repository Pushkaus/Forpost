using Forpost.Application.Contracts.Issues;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetAllIssuesQueryHandler: 
    IQueryHandler<IssuesFromManufacturingProcessQuery,
    IReadOnlyCollection<IssueFromManufacturingProcess>>
{
    private readonly IIssueReadRepository _issueReadRepository;
    public GetAllIssuesQueryHandler(IIssueReadRepository issueReadRepository)
    {
        _issueReadRepository = issueReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<IssueFromManufacturingProcess>>
        Handle(IssuesFromManufacturingProcessQuery request, CancellationToken cancellationToken) =>
        await _issueReadRepository.GetAllFromManufacturingProcessId(request.ManufacturingProcessId, cancellationToken);
}
public sealed record IssuesFromManufacturingProcessQuery(Guid ManufacturingProcessId): 
    IQuery<IReadOnlyCollection<IssueFromManufacturingProcess>>;