using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.SortOut;

public class ProductVersion : DomainAuditableEntity
{
    public Guid ProductId { get; set; }
}