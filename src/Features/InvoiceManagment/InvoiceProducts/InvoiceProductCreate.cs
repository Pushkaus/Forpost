namespace Forpost.Features.InvoiceManagment.InvoiceProducts;

public class InvoiceProductCreate
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}