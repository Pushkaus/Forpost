using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.InvoiceManagement;

public sealed class CompositionInvoice: DomainEntity
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public Guid CompletedProductId { get; set; }
}