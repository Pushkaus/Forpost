using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.CompletedProduct;

/// <summary>
/// Завершенный продукт
/// </summary>
public sealed class CompletedProduct : DomainEntity
{
    public static CompletedProduct Create(Guid manufacturingProcessId, Guid productDevelopmentId)
    {
        var completedProduct = new CompletedProduct()
        {
            ManufacturingProcessId = manufacturingProcessId,
            ProductDevelopmentId = productDevelopmentId,
            Status = CompletedProductStatus.OnStorage
        };
        return completedProduct;
    }

    public static CompletedProduct Ship()
    {
        var completedProduct = new CompletedProduct
        {
            Status = CompletedProductStatus.Shipped
        };
        return completedProduct;
    }
    
    public Guid ManufacturingProcessId { get; set; }
    public Guid ProductDevelopmentId { get; set; }
    public CompletedProductStatus Status { get; set; }
}