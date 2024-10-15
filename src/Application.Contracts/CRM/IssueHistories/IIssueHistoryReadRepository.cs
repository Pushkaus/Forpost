using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.CRM.IssueHistories;

public interface IIssueHistoryReadRepository: IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<IssueHistoryModel> Issues, int TotalCount)> GetAll(IssueHistoryFilter filter,
        CancellationToken cancellationToken);
}