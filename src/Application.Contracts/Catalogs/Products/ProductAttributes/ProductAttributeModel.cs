namespace Forpost.Application.Contracts.Catalogs.Products.ProductAttributes;

public sealed class ProductAttributeModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public Guid AttributeId { get; set; }
    public string AttributeName { get; set; }
    public List<string> Values { get; set; } = [];
}