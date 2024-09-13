using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.CompositionProduct;

public sealed class CompositionProduct: DomainEntity
{
    public static CompositionProduct Create(Guid productId, Guid itemId)
    {
        return new CompositionProduct
        {
            ProductId = productId,
            ItemId = itemId
        };
    }
    /// <summary>
    /// ID продукта относительно которого указывается состав
    /// </summary>
    public Guid ProductId { get; set; }
    /// <summary>
    /// ID компонента продукта
    /// </summary>
    public Guid ItemId { get; set; }
}