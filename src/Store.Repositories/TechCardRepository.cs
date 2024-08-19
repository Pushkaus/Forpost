using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories;

internal sealed class TechCardRepository: Repository<TechCard>, ITechCardRepository
{
    public TechCardRepository(ForpostContextPostgres db) : base(db)
    {
    }
}