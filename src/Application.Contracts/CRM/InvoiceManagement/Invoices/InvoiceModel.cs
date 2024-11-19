using Forpost.Domain.CRM.InvoiceManagement;

namespace Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;

public sealed class InvoiceModel
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public Guid ContractorId { get; set; }
    public string ContragentName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? PaymentDeadline { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
    public DateTimeOffset? DateClosing { get; set; }
    public Priority Priority { get; set; } = Priority.Normal;
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.NotPaid;
    public InvoiceStatus InvoiceStatus { get; set; } = InvoiceStatus.Created;
}