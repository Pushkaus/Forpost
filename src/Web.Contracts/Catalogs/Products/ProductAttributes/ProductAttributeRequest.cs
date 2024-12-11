namespace Forpost.Web.Contracts.Catalogs.Products.ProductAttributes;

public sealed class ProductAttributeRequest
{
    public Guid ProductId { get; set; }
    public Guid AttributeId { get; set; }
}