using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories;

internal sealed class ContragentRepository: Repository<Contragent>, IContragentRepository
{
    public ContragentRepository(ForpostContextPostgres db) : base(db)
    {
    }
}