using Forpost.Store.Enums;

namespace Forpost.Web.Contracts.Models.Invoices;

public class InvoiceUpdateRequest
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Guid ContragentId { get; set; }
    public Status Status { get; set; }
    public string? Description { get; set; }
    public int? DaysShipment { get; set; }
    public int? PaymentPercentage { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
}