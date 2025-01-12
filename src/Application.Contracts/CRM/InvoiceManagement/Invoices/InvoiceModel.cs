using Forpost.Domain.Crm.InvoiceManagement;

namespace Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;

public sealed class InvoiceModel
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public Guid ContractorId { get; set; }
    public string ContragentName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal PaymentPercentage { get; set; }
    public bool IsManufacturingOrderSent { get; set; }
    /// <summary>
    /// Дата создания счета
    /// </summary>
    public DateTimeOffset CreateDate { get; set; }
    /// <summary>
    /// Дата выставления счета
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? PaymentDeadline { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
    public DateTimeOffset? DateClosing { get; set; }
    public Priority Priority { get; set; }
    public PaymentStatus PaymentStatus { get; set; } 
    public InvoiceStatus InvoiceStatus { get; set; }
}