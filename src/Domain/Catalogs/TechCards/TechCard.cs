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
    public string Number { get; private set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; private set; }

    /// <summary>
    /// Ссылка на продукт, относительно которого составляется тех.карта
    /// </summary>
    public Guid ProductId { get; private set; }

    private TechCard(string number, string? description, Guid productId)
    {
        Number = number;
        Description = description;
        ProductId = productId;
    }
    /// <summary>
    /// Создание тех.карты
    /// </summary>
    public static TechCard Create(string number, string? description, Guid productId)
    {
        return new TechCard(number, description, productId);
    }
}