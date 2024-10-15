using AutoMapper;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class ContractorDomainRepository : DomainRepository<Contractor>, IContractorDomainRepository
{
    public ContractorDomainRepository(ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}