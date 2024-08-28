using AutoMapper;
using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class TechCardStepRepository : Repository<TechCardStep>, ITechCardStepRepository
{
    public TechCardStepRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<TechCardStep>> GetAllStepsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(techCardStep => techCardStep.TechCardId == techCardId)
            .Join(DbContext.Steps,
                techCardStep => techCardStep.StepId,
                step => step.Id,
                (techCardStep, step) => new { techCardStep, step }
            )
            .Join(DbContext.Operations,
                techCardStep => techCardStep.step.OperationId,
                operation => operation.Id,
                (techCardStep, operation) => new TechCardStep
                {
                    TechCardId = techCardId,
                    StepId = techCardStep.step.Id,
                    Number = techCardStep.techCardStep.Number,
                    Id = techCardStep.techCardStep.Id,
                }).ToListAsync(cancellationToken);
    }
}