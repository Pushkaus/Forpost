using Forpost.Domain.Primitives.EntityAnnotations;

namespace Forpost.Domain.Primitives.DomainAbstractions;

/// <summary>
/// Базовый интерфейс для доменных репозиториев с тупыми CRUD-ами 
/// </summary>
/// <typeparam name="TEntity">Сущность</typeparam>
public interface IDomainRepository<TEntity> : IDomainRepository where TEntity : class, IEntity
{
    public Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Guid Add(TEntity entity);
    public void Update(TEntity entity);
    public void DeleteById(Guid id);
}
/// <summary>
/// Маркерный интерфейс для доменных репозиториев (нужен для DI и constraint-ов)
/// </summary>
public interface IDomainRepository;