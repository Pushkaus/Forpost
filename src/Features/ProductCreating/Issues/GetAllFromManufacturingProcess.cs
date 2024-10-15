using Forpost.Application.Contracts.ProductCreating.Issues;
using Forpost.Domain.ProductCreating.Issue;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetAllIssuesQueryHandler: 
    IQueryHandler<IssuesFromManufacturingProcessQuery,
    IReadOnlyCollection<IssueFromManufacturingProcessModel>>
{
    private readonly IIssueReadRepository _issueReadRepository;

    private readonly IIssueDomainRepository _issueDomainRepository;

    private readonly ISender _sender;
    public GetAllIssuesQueryHandler(IIssueReadRepository issueReadRepository, ISender sender, IIssueDomainRepository issueDomainRepository)
    {
        _issueReadRepository = issueReadRepository;
        _sender = sender;
        _issueDomainRepository = issueDomainRepository;
    }

    public async ValueTask<IReadOnlyCollection<IssueFromManufacturingProcessModel>>
        Handle(IssuesFromManufacturingProcessQuery request, CancellationToken cancellationToken)
    {
        return await _issueReadRepository.GetAllFromManufacturingProcessId(request.ManufacturingProcessId,
            cancellationToken);
    }
}
public sealed record IssuesFromManufacturingProcessQuery(Guid ManufacturingProcessId): 
    IQuery<IReadOnlyCollection<IssueFromManufacturingProcessModel>>;