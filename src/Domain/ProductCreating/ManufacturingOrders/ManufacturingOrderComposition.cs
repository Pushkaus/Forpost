using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.ManufacturingOrders;

/// <summary>
/// Состав заказа на производство
/// </summary>
public sealed class ManufacturingOrderComposition : DomainEntity
{
    public Guid ManufacturingProcessOrderId { get; private set; }
    public Guid TechCardId { get; private set; }
    public int Quantity { get; private set; }

    public static ManufacturingOrderComposition Create(
        Guid manufacturingProcessOrderId,
        Guid techCardId,
        int quantity) 
        => new(manufacturingProcessOrderId, techCardId, quantity);

    public void ChangeQuantity(int quantity)
    {
        Quantity = quantity;
    }
    
    private ManufacturingOrderComposition(
        Guid manufacturingProcessOrderId,
        Guid techCardId,
        int quantity)
    {
        ManufacturingProcessOrderId = manufacturingProcessOrderId;
        TechCardId = techCardId;
        Quantity = quantity;
    }
}