using Forpost.Application.Contracts.CRM.IssueHistories;
using Mediator;

namespace Forpost.Features.Crm.IssueHistory;

internal sealed class
    GetAllQueryHandler : IQueryHandler<GetAllQuery, (IReadOnlyCollection<IssueHistoryModel> Issues, int TotalCount)>
{
    private readonly IIssueHistoryReadRepository _issueHistoryReadRepository;

    public GetAllQueryHandler(IIssueHistoryReadRepository issueHistoryReadRepository)
    {
        _issueHistoryReadRepository = issueHistoryReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<IssueHistoryModel> Issues, int TotalCount)> Handle(GetAllQuery query,
        CancellationToken cancellationToken)
    {
        return await _issueHistoryReadRepository.GetAll(query.Filter, cancellationToken);
    }
}

public record GetAllQuery(IssueHistoryFilter Filter)
    : IQuery<(IReadOnlyCollection<IssueHistoryModel> Issues, int TotalCount)>;