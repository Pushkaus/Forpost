using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories;

internal sealed class TechCardStepRepository: Repository<TechCardStep>, ITechCardStepRepositrory
{
    public TechCardStepRepository(ForpostContextPostgres db) : base(db)
    {
    }
}