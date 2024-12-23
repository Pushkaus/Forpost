using Forpost.Application.Contracts.CRM.IssueHistories;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class IssueHistoryReadRepository : IIssueHistoryReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public IssueHistoryReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<(IReadOnlyCollection<IssueHistoryModel> Issues, int TotalCount)> GetAll(IssueHistoryFilter filter,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}