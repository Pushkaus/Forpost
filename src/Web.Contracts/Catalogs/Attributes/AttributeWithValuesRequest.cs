namespace Forpost.Web.Contracts.Catalogs.Attributes;

public sealed class AttributeWithValuesRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> Values { get; set; }
}