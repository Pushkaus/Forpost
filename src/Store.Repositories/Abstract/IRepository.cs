using Forpost.Common.EntityAnnotations;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories.Abstract;

public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity
{
    public Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}