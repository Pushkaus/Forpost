namespace Forpost.Application.Contracts.Catalogs.Attributes;

public sealed class AttributeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> Values { get; set; }
}