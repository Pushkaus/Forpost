namespace Forpost.Web.Contracts.Catalogs.Attributes;

public sealed class AttributeRequest
{
    public string AttributeName { get; set; }
    public List<string> Values { get; set; }
}