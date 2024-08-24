namespace Forpost.Store.Repositories.Models.InvoiceProduct;

public class InvoiceWithProductsModel
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}