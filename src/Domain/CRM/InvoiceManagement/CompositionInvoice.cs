using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.InvoiceManagement;

public sealed class CompositionInvoice: DomainAuditableEntity
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public Guid CompletedProductId { get; set; }
}