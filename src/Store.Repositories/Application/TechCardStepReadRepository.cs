using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardSteps;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class TechCardStepReadRepository : ITechCardStepReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public TechCardStepReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityPagedResult<TechCardStepModel>> GetTechCardStepsAsync(Guid techCardId, TechCardStepFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.TechCardSteps
            .Where(tcs => tcs.TechCardId == techCardId)
            .Join(_dbContext.Steps,
                techCardStep => techCardStep.StepId,
                step => step.Id,
                (techCardStep, step) => new { techCardStep, step })
            .Join(_dbContext.Operations,
                combined => combined.step.OperationId,
                operation => operation.Id,
                (combined, operation) => new TechCardStepModel
                {
                    Id = combined.techCardStep.Id,
                    TechCardNumber = _dbContext.TechCards
                        .Where(tc => tc.Id == combined.techCardStep.TechCardId)
                        .Select(tc => tc.Number)
                        .FirstOrDefault(),
                    TechCardId = combined.techCardStep.TechCardId,
                    OperationName = operation.Name,
                    StepId = combined.step.Id,
                    Number = combined.techCardStep.Number
                })
            .AsQueryable();

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .OrderBy(x=>x.Number)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<TechCardStepModel>
        {
            TotalCount = totalCount,
            Items = items
        };
    }


    public Task<TechCardStepModel> GetTechCardStepAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}