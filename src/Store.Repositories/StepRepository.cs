using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Store.Repositories;

internal sealed class StepRepository: Repository<Step>, IStepRepository
{
    public StepRepository(ForpostContextPostgres db) : base(db)
    {
    }
}