using Forpost.Domain.ProductCreating.Issue;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetIssueByExecutorIdQueryHandler: IQueryHandler<GetIssuesByExecutorIdQuery, IReadOnlyCollection<Issue>>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    public GetIssueByExecutorIdQueryHandler(IIssueDomainRepository issueDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Issue>> Handle(GetIssuesByExecutorIdQuery query, CancellationToken cancellationToken) 
        => await _issueDomainRepository.GetIssuesByExecutorId(query.ExecutorId, cancellationToken);
}
public record GetIssuesByExecutorIdQuery(Guid ExecutorId): IQuery<IReadOnlyCollection<Issue>>;