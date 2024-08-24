namespace Forpost.Business.Sortout;

public class InvoiceProduct
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; } = default!;
    public int Quantity { get; set; }
}