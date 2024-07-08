namespace Forpost.Business.Models.InvoiceProducts;

public class InvoiceProductCreateModel
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}