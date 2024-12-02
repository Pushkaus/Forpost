using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.ManufacturingOrders;

/// <summary>
/// Состав заказа на производство
/// </summary>
public sealed class ManufacturingOrderComposition : DomainEntity
{
    public Guid ManufacturingProcessOrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public static ManufacturingOrderComposition Create(Guid manufacturingProcessOrderId, Guid productId, int quantity)
    {
        return new ManufacturingOrderComposition(manufacturingProcessOrderId, productId, quantity);
    }

    public void ChangeQuantity(int quantity)
    {
        Quantity = quantity;
    }
    
    private ManufacturingOrderComposition(
        Guid manufacturingProcessOrderId,
        Guid productId,
        int quantity)
    {
        ManufacturingProcessOrderId = manufacturingProcessOrderId;
        ProductId = productId;
        Quantity = quantity;
    }
}