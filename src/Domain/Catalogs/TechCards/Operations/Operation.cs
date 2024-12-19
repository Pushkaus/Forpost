using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.TechCards.Operations;

public sealed class Operation : DomainEntity
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public OperationType Type { get; private set; }
    
    public static Operation Create(string name, string? description, OperationType type)
    {
        return new Operation(name, description, type);
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }
    private Operation(string name, string? description, OperationType type)
    {
        Name = name;
        Description = description;
        Type = type;
    }
}