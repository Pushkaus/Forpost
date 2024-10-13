using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.CRM.IssueHistory;

public interface IIssueHistoryReadRepository: IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<IssueHistoryModel> Issues, int TotalCount)> GetAll(IssueHistoryFilter filter,
        CancellationToken cancellationToken);
}