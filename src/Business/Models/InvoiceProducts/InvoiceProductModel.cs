namespace Forpost.Business.Models.InvoiceProducts;

public class InvoiceProductModel
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}