using Forpost.Common.EntityAnnotations;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories.Abstract;

public interface IRepository<TEntity>: IRepository where TEntity : class, IEntity
{
    public Task<Guid> AddAsync(TEntity entity);
    public Task<IReadOnlyList<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(Guid id);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteByIdAsync(Guid id);
}