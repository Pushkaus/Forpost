using Forpost.Application.Contracts.ProductCreating.Issues;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetIssueByExecutorIdQueryHandler: 
    IQueryHandler<GetIssuesByExecutorIdQuery, (IReadOnlyCollection<IssueModel> Issues, int TotalCount)>
{
    private readonly IIssueReadRepository _issueReadRepository;
    
    public GetIssueByExecutorIdQueryHandler(
        IIssueReadRepository issueReadRepository)
    {
        _issueReadRepository = issueReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)> 
        Handle(GetIssuesByExecutorIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _issueReadRepository.GetIssuesByExecutorId(query.ExecutorId, cancellationToken, query.Skip,
            query.Limit);
        return (result.Issues, result.TotalCount);
    }
}
public record GetIssuesByExecutorIdQuery(Guid ExecutorId, int Skip, int Limit): 
    IQuery<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)>;