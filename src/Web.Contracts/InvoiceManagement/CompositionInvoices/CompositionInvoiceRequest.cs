using System.Collections.ObjectModel;

namespace Forpost.Web.Contracts.InvoiceManagement.CompositionInvoices;

public sealed class CompositionInvoiceRequest
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public IReadOnlyCollection<Guid> CompletedProductIds { get; set; }
}
