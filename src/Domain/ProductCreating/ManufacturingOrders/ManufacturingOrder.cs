using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.ManufacturingOrders;

/// <summary>
/// Заказ на производство
/// </summary>
public sealed class ManufacturingOrder : AggregateRoot
{
    public Guid InvoiceId { get; private set; }
    public string? Comment { get; private set; }
    public ManufacturingOrderStatus ManufacturingOrderStatus { get; private set; }

    public static ManufacturingOrder Create(Guid invoiceId) 
        => new(invoiceId, null, ManufacturingOrderStatus.Pending);

    public void ChangeComment(string comment)
    {
        Comment = comment;
    }
    
    private ManufacturingOrder(
        Guid invoiceId,
        string? comment,
        ManufacturingOrderStatus manufacturingOrderStatus)
    {
        InvoiceId = invoiceId;
        Comment = comment;
        ManufacturingOrderStatus = manufacturingOrderStatus;
    }
    
}