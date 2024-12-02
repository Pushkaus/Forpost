using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.ManufacturingOrder;

/// <summary>
/// Заказ на производство
/// </summary>
public sealed class ManufacturingOrder : AggregateRoot
{
    public Guid InvoiceId { get; private set; }
    public string? Description { get; private set; }
    public ManufacturingOrderStatus ManufacturingOrderStatus { get; private set; }

    public static ManufacturingOrder Create(Guid invoiceId, string? description) 
        => new(invoiceId, description, ManufacturingOrderStatus.Pending);

    public void ChangeDescription(string description)
    {
        Description = description;
    }
    
    private ManufacturingOrder(
        Guid invoiceId,
        string? description,
        ManufacturingOrderStatus manufacturingOrderStatus)
    {
        InvoiceId = invoiceId;
        Description = description;
        ManufacturingOrderStatus = manufacturingOrderStatus;
    }
    
}