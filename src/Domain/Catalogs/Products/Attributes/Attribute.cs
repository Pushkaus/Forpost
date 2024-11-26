using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Products.Attributes;

public sealed class Attribute: DomainEntity
{
    public string Name { get; private set; }
    public string PossibleValuesJson { get; private set; } 

    private Attribute(string name)
    {
        Name = name;
    }

    public static Attribute Create(string name)
    {
        return new Attribute(name);
    }
    
    public void AddPossibleValue(List<string> values)
    {
        foreach (var value in values)
        {
            if (!PossibleValuesJson.Contains(value))
            {
                PossibleValuesJson.Add(value);
            }
        }
    }
}