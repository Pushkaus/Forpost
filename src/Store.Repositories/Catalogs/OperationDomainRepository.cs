using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.Operations;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class OperationDomainRepository : DomainRepository<Operation>, IOperationDomainRepository
{
    public OperationDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}