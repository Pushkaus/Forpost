using AutoMapper;
using Forpost.Domain.CRM.PriceLists;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CRM.PriceListes;

internal sealed class PriceListDomainRepository : DomainRepository<PriceList>, IPriceListDomainRepository
{
    public PriceListDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }
}