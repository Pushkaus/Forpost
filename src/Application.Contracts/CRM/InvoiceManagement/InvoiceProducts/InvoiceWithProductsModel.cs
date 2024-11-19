namespace Forpost.Application.Contracts.InvoiceManagment.InvoiceProducts;

public sealed class InvoiceWithProductsModel
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}