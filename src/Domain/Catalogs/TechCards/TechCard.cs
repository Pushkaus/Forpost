using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.TechCards;

/// <summary>
/// Технологическая карта
/// </summary>
public sealed class TechCard : AggregateRoot
{
    /// <summary>
    /// Номер тех.карты
    /// </summary>
    public string Number { get; set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Ссылка на продукт, относительно которого составляется тех.карта
    /// </summary>
    public Guid ProductId { get; set; }
}