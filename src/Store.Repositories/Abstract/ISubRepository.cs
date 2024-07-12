using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Repositories.Abstract;

public interface ISubRepository<TEntity>: IRepository<TEntity> where TEntity : class, IEntity
{
}