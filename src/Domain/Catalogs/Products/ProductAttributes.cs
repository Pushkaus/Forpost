using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Products;

public sealed class ProductAttributes: DomainEntity
{
    public Guid ProductId { get; set; }
    public Guid AttributeId { get; set; }
    public string Value { get; set; }
}