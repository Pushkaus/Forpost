using Forpost.Common.EntityAnnotations;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories.Abstract;

public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity
{
    public Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Guid Add(TEntity entity);
    public void Update(TEntity entity);
    public void DeleteById(Guid id);
}