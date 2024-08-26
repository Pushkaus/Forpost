using Forpost.Common.EntityAnnotations;

namespace Forpost.Domain.Catalogs.Operations;

public sealed class Operation : IEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public OperationType Type { get; set; }
    public Guid Id { get; set; }
}