using Forpost.Application.Contracts.Issues;
using MediatR;

namespace Forpost.Application.ProductCreating.Issues;

internal sealed class GetAllIssuesQueryHandler: 
    IRequestHandler<IssuesFromManufacturingProcessQuery,
    IReadOnlyCollection<IssueFromManufacturingProcess>>
{
    private readonly IIssueReadRepository _issueReadRepository;
    public GetAllIssuesQueryHandler(IIssueReadRepository issueReadRepository)
    {
        _issueReadRepository = issueReadRepository;
    }

    public async Task<IReadOnlyCollection<IssueFromManufacturingProcess>>
        Handle(IssuesFromManufacturingProcessQuery request, CancellationToken cancellationToken) =>
        await _issueReadRepository.GetAllFromManufacturingProcessId(request.ManufacturingProcessId, cancellationToken);
}
public sealed record IssuesFromManufacturingProcessQuery(Guid ManufacturingProcessId): 
    IRequest<IReadOnlyCollection<IssueFromManufacturingProcess>>;