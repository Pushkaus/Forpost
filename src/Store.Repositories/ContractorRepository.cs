using AutoMapper;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class ContractorRepository : Repository<Contractor>, IContractorRepository
{
    public ContractorRepository(ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}