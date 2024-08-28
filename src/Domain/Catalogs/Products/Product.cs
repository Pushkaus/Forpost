using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.Catalogs.Products;

public sealed class Product : DomainAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Version { get; set; } = null!;
    public Guid? CategoryId { get; set; }
}