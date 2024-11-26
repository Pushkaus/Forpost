namespace Forpost.Web.Contracts.Catalogs.Attributes;

public sealed class AttributeValuesRequest
{
    public List<string> AttributeValues { get; set; } = new List<string>();
}