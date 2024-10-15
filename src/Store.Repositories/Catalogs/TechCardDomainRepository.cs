using AutoMapper;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class TechCardDomainRepository : DomainRepository<TechCard>, ITechCardDomainRepository
{
    public TechCardDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}