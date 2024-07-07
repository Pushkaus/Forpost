namespace Forpost.Store.Contracts;
/// <summary>
/// Маркерный интерфейс для сущности
/// </summary>
public interface IEntity
{
    public Guid Id { get; set; }
}