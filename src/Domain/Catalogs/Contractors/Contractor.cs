using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Contractors;

/// <summary>
/// Контрагент
/// </summary>
public sealed class Contractor : AggregateRoot
{
    private Contractor(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public static Contractor New(string name)
    {
        var contractor = new Contractor(name);
        
        contractor.Raise(new ContractorAdded(contractor.Id));
        return contractor;
    }

    public string Name { get; private set; }
}