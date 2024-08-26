using AutoMapper;
using Forpost.Domain.Catalogs.Operations;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class OperationRepository : Repository<Operation>, IOperationRepository
{
    public OperationRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}