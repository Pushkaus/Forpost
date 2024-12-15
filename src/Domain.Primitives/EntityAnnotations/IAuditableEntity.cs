namespace Forpost.Domain.Primitives.EntityAnnotations;

/// <summary>
/// Сущность с аудит полями
/// </summary>
public interface IAuditableEntity
{
    /// <summary>
    /// Когда создана
    /// </summary>
    DateTimeOffset CreatedAt { get; }
    
    /// <summary>
    /// Кем создана
    /// </summary>
    Guid CreatedById { get; }
    
    /// <summary>
    /// Когда обновлена
    /// </summary>
    DateTimeOffset UpdatedAt { get; }
    
    /// <summary>
    /// Кем обновлена
    /// </summary>
    Guid UpdatedById { get; }
    
    /// <summary>
    /// Когда удалена
    /// </summary>
    DateTimeOffset? DeletedAt { get; }
    
    /// <summary>
    /// Кем удалена
    /// </summary>
    Guid? DeletedById { get; }
}