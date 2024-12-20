using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.TechCards.TechCardItems;

/// <summary>
/// Компонент, в составе тех.карты
/// </summary>
public sealed class TechCardItem : DomainEntity
{
    public Guid TechCardId { get; private set; }

    /// <summary>
    /// Ссылка на продукт, из которого состоит целевой продукт в тех.карте
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Необходимое количество, для создания единицы целевого продукта
    /// </summary>
    public int Quantity { get; private set; }

    public static TechCardItem Add(Guid techCardId, Guid productId, int quantity) 
        => new(techCardId, productId, quantity);

    private TechCardItem(Guid techCardId, Guid productId, int quantity)
    {
        TechCardId = techCardId;
        ProductId = productId;
        Quantity = quantity;
    }
}