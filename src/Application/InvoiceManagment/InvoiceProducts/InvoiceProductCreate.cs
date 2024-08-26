namespace Forpost.Application.SortOut;

public class InvoiceProductCreate
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}