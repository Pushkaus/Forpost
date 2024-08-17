using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Catalog;
/// <summary>
/// Технологическая карта
/// </summary>
public sealed class TechnologicalCard: IEntity
{
    public Guid Id { get; set; }
    /// <summary>
    /// Номер тех.карты
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Ссылка на продукт, относительно которого составляется тех.карта
    /// </summary>
    public Guid ProductId { get; set; }
    /// <summary>
    /// Создатель тех.карты
    /// </summary>
    public Guid CreatedById { get; set; }
}