using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities.Catalog;

public sealed class OperationEntity : IEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public OperationType Type { get; set; }
    public Guid Id { get; set; }
}