using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories;

internal sealed class OperationRepository: Repository<Operation>, IOperationRepository
{
    public OperationRepository(ForpostContextPostgres db) : base(db)
    {
    }
}