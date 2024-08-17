using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public sealed class Operation: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}