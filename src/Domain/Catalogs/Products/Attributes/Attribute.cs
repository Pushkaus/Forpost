using System.Text.Json;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Products.Attributes;

public sealed class Attribute: DomainEntity
{
    public string Name { get; private set; }
    public string PossibleValuesJson { get; private set; }

    private Attribute(string name)
    {
        Name = name;
        PossibleValuesJson = "[]";
    }

    public static Attribute Create(string name)
    {
        return new Attribute(name);
    }
    
    public void AddPossibleValue(List<string> values)
    {
        var possibleValues = JsonSerializer.Deserialize<List<string>>(PossibleValuesJson) ?? [];
        foreach (var value in values)
        {
            if (!possibleValues.Contains(value))
            {
                possibleValues.Add(value);
            }
        }
        PossibleValuesJson = JsonSerializer.Serialize(possibleValues);
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
    public void UpdatePossibleValues(List<string> values)
    {
        PossibleValuesJson = JsonSerializer.Serialize(values);
    }
}