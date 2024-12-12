namespace Forpost.Web.Contracts.Catalogs.Products.ProductAttributes;

public sealed class UpdateProductAttributeRequest
{
    public List<string> Values { get; set; } = new List<string>();
}