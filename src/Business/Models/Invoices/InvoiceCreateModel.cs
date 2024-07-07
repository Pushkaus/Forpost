namespace Forpost.Business.Models.Invoices;

public class InvoiceCreateModel
{
    public string Number { get; set; }
    public string Contragent { get; set; }
    public string? Description { get; set; }
}