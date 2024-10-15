using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Products;

public sealed class ProductVersion : DomainAuditableEntity
{
    public Guid ProductId { get; set; }
}