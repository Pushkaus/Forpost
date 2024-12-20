using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardItems;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class TechCardItemDomainRepository : DomainRepository<TechCardItem>, ITechCardItemDomainRepository
{
    public TechCardItemDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyCollection<TechCardItem>> 
        GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.TechCardId == techCardId)
            .ToListAsync(cancellationToken);
    }
}