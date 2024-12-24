namespace Forpost.Domain.Primitives.EntityAnnotations;

/// <summary>
/// Сущность
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }
}