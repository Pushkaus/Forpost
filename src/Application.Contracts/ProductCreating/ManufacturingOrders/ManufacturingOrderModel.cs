using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.ProductCreating.ManufacturingOrders;

namespace Forpost.Application.Contracts.ProductCreating.ManufacturingOrders;

public sealed class ManufacturingOrderModel
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public string Number { get;  set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public string? Comment { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public ManufacturingOrderStatus ManufacturingOrderStatus { get; set; }
}
