using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.ManufacturingOrder;

/// <summary>
/// Состав заказа на производство
/// </summary>
public sealed class ManufacturingProductOrder : DomainEntity
{
    public Guid ManufacturingProcessOrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public static ManufacturingProductOrder Create(Guid manufacturingProcessOrderId, Guid productId, int quantity)
    {
        return new ManufacturingProductOrder(manufacturingProcessOrderId, productId, quantity);
    }
    
    private ManufacturingProductOrder(
        Guid manufacturingProcessOrderId,
        Guid productId,
        int quantity)
    {
        ManufacturingProcessOrderId = manufacturingProcessOrderId;
        ProductId = productId;
        Quantity = quantity;
    }
}