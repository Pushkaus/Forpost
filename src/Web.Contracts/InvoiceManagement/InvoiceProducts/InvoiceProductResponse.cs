namespace Forpost.Web.Contracts.InvoiceManagement.InvoiceProducts;

public class InvoiceProductResponse
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}