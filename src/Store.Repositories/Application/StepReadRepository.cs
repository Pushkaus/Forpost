using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.Steps;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class StepReadRepository : IStepReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public StepReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityPagedResult<StepModel>> GetAllStepsAsync(StepFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.Steps
            .Join(_dbContext.Operations,
                step => step.OperationId,
                operation => operation.Id,
                (step, operation) => new StepModel
                {
                    Id = step.Id,
                    OperationName = operation.Name,
                    OperationId = step.OperationId,
                    Description = step.Description,
                    Duration = step.Duration
                })
            .AsQueryable();

        if (filter.OperationId.HasValue)
        {
            query = query.Where(step => step.OperationId == filter.OperationId.Value);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var steps = await query
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<StepModel>
        {
            TotalCount = totalCount,
            Items = steps
        };
    }


    public async Task<StepModel?> GetStepByIdAsync(Guid stepId, CancellationToken cancellationToken)
    {
        var step = await _dbContext.Steps
            .Where(s => s.Id == stepId)
            .Join(_dbContext.Operations,
                step => step.OperationId,
                operation => operation.Id,
                (step, operation) => new StepModel
                {
                    Id = step.Id,
                    OperationName = operation.Name,
                    OperationId = step.OperationId,
                    Description = step.Description,
                    Duration = step.Duration
                })
            .FirstOrDefaultAsync(cancellationToken);

        return step;
    }

}