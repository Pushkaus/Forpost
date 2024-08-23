using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.TechCardStep;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class TechCardStepRepository: Repository<TechCardStep>, ITechCardStepRepositrory
{
    public TechCardStepRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<StepsInTechCard>> GetAllStepsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
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
                (techCardStep, operation) => new StepsInTechCard
                {
                    TechCardId = techCardId,
                    StepId = techCardStep.step.Id,
                    StepName = operation.Name,
                    StepDescription = techCardStep.step.Description,
                    Number = techCardStep.techCardStep.Number,
                    Id = techCardStep.techCardStep.Id,
                }).ToListAsync(cancellationToken);
    }
}