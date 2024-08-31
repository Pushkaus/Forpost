using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.SortOut;

public sealed class ProductVersion : DomainAuditableEntity
{
    public Guid ProductId { get; set; }
}