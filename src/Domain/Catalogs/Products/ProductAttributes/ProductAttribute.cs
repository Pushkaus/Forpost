using System.Text.Json;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Products.ProductAttributes;

public sealed class ProductAttribute: DomainEntity
{
    public Guid ProductId { get; private set; }
    public Guid AttributeId { get; private set; }
    public string Values { get; private set; }
    
    private ProductAttribute(Guid productId, Guid attributeId)
    {
        ProductId = productId;
        AttributeId = attributeId;
        Values = "[]";
    }

    public static ProductAttribute Create(Guid productId, Guid attributeId)
    {
        return new ProductAttribute(productId, attributeId);
    }

    public void AddValues(List<string> values)
    {
        var possibleValues = JsonSerializer.Deserialize<List<string>>(Values) ?? [];
        foreach (var value in values)
        {
            if (!possibleValues.Contains(value))
            {
                possibleValues.Add(value);
            }
        }
        Values = JsonSerializer.Serialize(possibleValues);
    }

    public void UpdatePossibleValues(List<string> values)
    {
        Values = JsonSerializer.Serialize(values);
    }
}