namespace Forpost.Web.Contracts.Models.InvoiceProducts;

public class InvoiceProductResponse
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}