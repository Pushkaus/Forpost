namespace Forpost.Business.Models.Invoices;

public class InvoiceUpdateModel
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int? DaysShipment { get; set; }
    public int? PaymentPercentage { get; set; }
    public DateTimeOffset? DateShipment { get; set; }

}