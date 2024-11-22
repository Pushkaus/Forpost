using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.ChangeLogs;
using Forpost.Domain.ChangeLogs;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ChangeLogReadRepository : IChangeLogReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ChangeLogReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityPagedResult<ChangeLog>> GetChangeLogsByIdAsync(Guid id, ChangeLogFilter filter,
        CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.ChangeLogs.Where(c => c.EntityId == id).CountAsync(cancellationToken);
        var result = await _dbContext.ChangeLogs
            .Where(c => c.EntityId == id)
            .OrderByDescending(c => c.CreatedAt)
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);
        return new EntityPagedResult<ChangeLog>
        {
            Items = result,
            TotalCount = totalCount
        };
    }
}