using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.TechCardStep;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class TechCardStepRepository: Repository<TechCardStep>, ITechCardStepRepositrory
{
    public TechCardStepRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<StepsInTechCard>> GetAllStepsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(techCardStep => techCardStep.TechCardId == techCardId)
            .Join(_db.Steps,
                techCardStep => techCardStep.StepId,
                step => step.Id,
                (techCardStep, step) => new { techCardStep, step }
            )
            .Join(_db.Operations,
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