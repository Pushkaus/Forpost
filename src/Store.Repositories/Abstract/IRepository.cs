using Forpost.Store.Contracts;

namespace Forpost.Store.Repositories.Abstract;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    public Task AddAsync(TEntity entity);
    public Task<IReadOnlyList<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(Guid id);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteByIdAsync(Guid id);
}