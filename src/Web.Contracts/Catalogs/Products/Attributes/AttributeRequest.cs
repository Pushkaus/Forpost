namespace Forpost.Web.Contracts.Catalogs.Products.Attributes;

public sealed class AttributeRequest
{
    public string AttributeName { get; set; }
    public List<string> Values { get; set; }
}