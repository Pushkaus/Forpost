namespace Forpost.Domain.Primitives.EntityAnnotations;

/// <summary>
/// Сущность, существующая во временных рамках
/// </summary>
public interface ITimeFrameEntity
{
    /// <summary>
    /// Дата начала
    /// </summary>
    public DateTimeOffset? StartTime { get; }
    
    /// <summary>
    /// Дата конца
    /// </summary>
    public DateTimeOffset? EndTime { get; }
}