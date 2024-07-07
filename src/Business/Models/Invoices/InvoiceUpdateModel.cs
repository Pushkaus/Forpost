namespace Forpost.Business.Models.Invoices;

public class InvoiceUpdateModel
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Contragent { get; set; }
    public string? Description { get; set; }
}