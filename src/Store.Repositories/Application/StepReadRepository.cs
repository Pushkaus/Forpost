using Forpost.Application.Contracts.Catalogs.Steps;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class StepReadRepository: IStepReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public StepReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<StepWithSummary?> GetStepWithSummaryByIdAsync(Guid stepId, CancellationToken cancellationToken)
    {
        return await _dbContext.Steps.Where(entity => entity.Id == stepId)
            .Join(_dbContext.Operations,
                step => step.OperationId,
                operation => operation.Id,
                (step, operation) => new StepWithSummary
                {
                    TechCardId = step.TechCardId,
                    OperationName = operation.Name,
                    Description = step.Description,
                    Duration = step.Duration,
                    Cost = step.Cost,
                    UnitOfMeasureRead = UnitOfMeasureRead.Piece,
                }).FirstOrDefaultAsync(cancellationToken);
    }
}