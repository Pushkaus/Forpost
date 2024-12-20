using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardSteps;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class TechCardStepDomainRepository : DomainRepository<TechCardStep>, ITechCardStepDomainRepository
{
    public TechCardStepDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<TechCardStep>> 
        GetAllStepsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(techCardStep => techCardStep.TechCardId == techCardId)
            .ToListAsync(cancellationToken);
    }
}