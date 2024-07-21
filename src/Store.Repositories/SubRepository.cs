using Forpost.Common.EntityAnnotations;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal class SubRepository<TEntity>: Repository<TEntity>, ISubRepository<TEntity> where TEntity : class, IEntity
{
    public SubRepository(ForpostContextPostgres db) : base(db)
    {
    }

}