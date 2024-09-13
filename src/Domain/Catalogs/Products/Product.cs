using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Products;

public sealed class Product : DomainAuditableEntity
{
    public static Product Create(string name, string version = "v1")
    {
        var product = new Product
        {
            Name = name,
            Version = version,
        };
        return product;
    }
    public string Name { get; set; } = null!;
    public string Version { get; set; } = null!;
    public Guid? CategoryId { get; set; }
}