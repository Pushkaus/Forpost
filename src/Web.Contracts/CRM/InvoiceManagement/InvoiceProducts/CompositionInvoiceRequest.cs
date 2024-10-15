namespace Forpost.Web.Contracts.CRM.InvoiceManagement.InvoiceProducts;

public sealed class CompositionInvoiceRequest
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public IReadOnlyCollection<Guid> CompletedProductIds { get; set; }
}
