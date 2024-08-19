namespace Forpost.Common.EntityAnnotations;

/// <summary>
///     Маркерный интерфейс для сущности
/// </summary>
public interface IEntity
{
    public Guid Id { get; set; }
}