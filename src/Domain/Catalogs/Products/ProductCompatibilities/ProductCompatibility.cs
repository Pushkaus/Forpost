using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Products.ProductCompatibilities;

public sealed class ProductCompatibility: DomainEntity
{
    public Guid ProductId { get; private set; }
    public Guid ParentProductId { get; private set; }

    public static ProductCompatibility Create(Guid productId, Guid parentProductId)
    {
        return new ProductCompatibility(productId, parentProductId);
    }
    
    private ProductCompatibility(Guid productId, Guid parentProductId)
    {
        ProductId = productId;
        ParentProductId = parentProductId;
    }

    
}