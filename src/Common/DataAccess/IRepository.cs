using Forpost.Common.EntityAnnotations;

namespace Forpost.Common.DataAccess;

/// <summary>
/// Базовый интерфейс с тупыми CRUD-ами
/// </summary>
/// <typeparam name="TEntity">Сущность</typeparam>
public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity
{
    public Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Guid Add(TEntity entity);
    public void Update(TEntity entity);
    public void DeleteById(Guid id);
}
/// <summary>
/// Маркерный интерфейс для репозиториев (нужен для DI и constraint-ов)
/// </summary>
public interface IRepository;

/// <summary>
/// Маркерный интерфейс для репозиториев, специфичных для приложения. (ТОЛЬКО ЧТЕНИЕ)
/// </summary>
public interface IApplicationReadRepository;