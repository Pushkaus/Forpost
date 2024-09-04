namespace Forpost.Application.Contracts.InvoiceProducts;

public sealed class InvoiceWithProducts
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}