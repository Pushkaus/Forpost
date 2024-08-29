using AutoMapper;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class IssueDomainRepository : DomainRepository<Issue>, IIssueDomainRepository
{
    public IssueDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    
}