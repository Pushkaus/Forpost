using AutoMapper;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class ContractorRepresentativesDomainRepository : DomainRepository<ContractorRepresentative>,
    IContractorRepresentativesDomainRepository
{
    public ContractorRepresentativesDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider,
        IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
}