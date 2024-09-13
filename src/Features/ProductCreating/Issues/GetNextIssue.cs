using Forpost.Domain.ProductCreating.Issue;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetNextIssueQueryHandler: IQueryHandler<GetNextIssueQuery, Guid>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    public GetNextIssueQueryHandler(IIssueDomainRepository issueDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
    }

    public ValueTask<Guid> Handle(GetNextIssueQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public record GetNextIssueQuery(Guid IssueId): IQuery<Guid>;