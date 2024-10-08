using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.TechCardItems;

/// <summary>
/// Компонент, в составе тех.карты
/// </summary>
public sealed class TechCardItem : DomainEntity
{
    public Guid TechCardId { get; set; }

    /// <summary>
    /// Ссылка на продукт, из которого состоит целевой продукт в тех.карте
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Необходимое количество, для создания единицы целевого продукта
    /// </summary>
    public int Quantity { get; set; }
}