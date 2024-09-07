using Forpost.Domain.ProductCreating.Issue;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetIssueNumberQueryHandler: IQueryHandler<GetIssueNumberQuery, int>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    public GetIssueNumberQueryHandler(IIssueDomainRepository issueDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
    }

    public async ValueTask<int> Handle(GetIssueNumberQuery query, CancellationToken cancellationToken) 
        => await _issueDomainRepository.GetIssueNumber(query.TechCardId, query.StepId, cancellationToken);
}
public record GetIssueNumberQuery(Guid TechCardId, Guid StepId): IQuery<int>;