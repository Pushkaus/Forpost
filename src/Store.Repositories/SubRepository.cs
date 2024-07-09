using Forpost.Store.Contracts;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class SubRepository<TEntity>: Repository<TEntity>, ISubRepository<TEntity> where TEntity : class, IEntity
{
    public SubRepository(ForpostContextPostgres db) : base(db)
    {
    }

}