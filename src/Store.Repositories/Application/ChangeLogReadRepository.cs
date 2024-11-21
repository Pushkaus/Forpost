using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.ChangeLogs;
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

    public async Task<EntityPagedResult<ChangeLogModel>> GetChangeLogsByIdAsync(Guid Id, ChangeLogFilter filter,
        CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.ChangeLogs.Where(c => c.EntityId == Id).CountAsync(cancellationToken);
        var result = await _dbContext.ChangeLogs
            .Where(c => c.EntityId == Id)
            .OrderByDescending(c => c.CreatedAt)
            .Join(_dbContext.Employees,
                changeLog => changeLog.CreatedById,
                employee => employee.Id,
                (changeLog, employee) => new ChangeLogModel
                {
                    Id = changeLog.Id,
                    EntityId = changeLog.EntityId,
                    PropertyName = changeLog.PropertyName,
                    OldValue = changeLog.OldValue,
                    NewValue = changeLog.NewValue,
                    CreatedAt = changeLog.CreatedAt,
                    CreatedById = changeLog.CreatedById,
                    CreatedBy = employee.FirstName + " " + employee.LastName,
                })
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);
        return new EntityPagedResult<ChangeLogModel>
        {
            Items = result,
            TotalCount = totalCount
        };
    }
}