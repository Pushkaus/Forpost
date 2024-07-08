namespace Forpost.Web.Contracts.Models.InvoiceProducts;

public class InvoiceProductRequest
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}