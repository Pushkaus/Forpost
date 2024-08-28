using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.Catalogs.Operations;

public sealed class Operation : DomainEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public OperationType Type { get; set; } 
}