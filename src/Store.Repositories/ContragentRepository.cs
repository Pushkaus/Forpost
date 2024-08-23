using AutoMapper;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories;

internal sealed class ContragentRepository : Repository<Contractor>, IContragentRepository
{
    public ContragentRepository(ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }
}