namespace Forpost.Web.Contracts.CRM.InvoiceManagement.InvoiceProducts;

public class InvoiceProductRequest
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}