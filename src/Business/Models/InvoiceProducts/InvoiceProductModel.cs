namespace Forpost.Business.Models.InvoiceProducts;

public class InvoiceProductModel
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}