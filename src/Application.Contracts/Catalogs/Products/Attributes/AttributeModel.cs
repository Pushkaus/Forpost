namespace Forpost.Application.Contracts.Catalogs.Products.Attributes;

public sealed class AttributeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> Values { get; set; }
}