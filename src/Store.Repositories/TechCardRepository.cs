using AutoMapper;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class TechCardRepository : Repository<TechCard>, ITechCardRepository
{
    public TechCardRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}