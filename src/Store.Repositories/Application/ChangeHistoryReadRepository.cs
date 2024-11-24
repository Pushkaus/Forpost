using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Changes;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ChangeHistoryReadRepository : IChangeHistoryReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ChangeHistoryReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityPagedResult<ChangeHistoryModel>> GetChangeLogsByIdAsync(Guid id, ChangeLogFilter filter,
        CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.ChangeHistory.Where(c => c.EntityId == id).CountAsync(cancellationToken);
        var result = await _dbContext.ChangeHistory
            .Where(c => c.EntityId == id)
            .Join(_dbContext.Employees,
                change => change.UpdatedById,
                employee => employee.Id,
                (change, employee) => new ChangeHistoryModel
                {
                    Id = change.Id,
                    EntityId = change.EntityId,
                    EntityName = change.EntityName,
                    PropertyName = change.PropertyName,
                    Value = change.Value,
                    UpdatedAt = change.UpdatedAt,
                    UpdatedById = change.UpdatedById,
                    UpdatedByName = employee.FirstName + " " + employee.LastName,
                })
            .OrderByDescending(c => c.UpdatedAt)
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);
        
        return new EntityPagedResult<ChangeHistoryModel>
        {
            Items = result,
            TotalCount = totalCount
        };
    }
}