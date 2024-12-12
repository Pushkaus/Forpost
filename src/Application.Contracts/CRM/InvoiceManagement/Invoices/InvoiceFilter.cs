namespace Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;

public sealed class InvoiceFilter
{
    public string? Number { get; set; }
    public Guid? ContractorId { get;  set; }
    public DateTimeOffset? DateShipment { get;  set; } 
    public DateTimeOffset? DateClosing { get;  set; } 
    public int? Priority { get;  set; }
    public int? PaymentStatus { get;  set; } 
    public int? InvoiceStatus { get;  set; } 
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}