using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;

namespace Forpost.Store.Repositories;

internal sealed class TechCardItemRepository: Repository<TechCardItem>, ITechCardItemRepository
{
    public TechCardItemRepository(ForpostContextPostgres db) : base(db)
    {
    }
}