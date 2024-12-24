using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardOperations;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class TechCardOperationDomainRepository : DomainRepository<TechCardOperation>, ITechCardOperationDomainRepository
{
    public TechCardOperationDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<TechCardOperation>> 
        GetAllOperationsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(techCardStep => techCardStep.TechCardId == techCardId)
            .ToListAsync(cancellationToken);
    }
}