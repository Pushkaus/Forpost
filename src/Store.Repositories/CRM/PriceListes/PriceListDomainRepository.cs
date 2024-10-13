using AutoMapper;
using Forpost.Domain.CRM.PriceList;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CRM.PriceListes;

internal sealed class PriceListDomainRepository : DomainRepository<PriceList>, IPriceListDomainRepository
{
    public PriceListDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }
}