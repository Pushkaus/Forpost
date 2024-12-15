namespace Forpost.Web.Contracts.Catalogs.Products.Attributes;

public sealed class AttributeWithValuesRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> Values { get; set; }
}