using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities.Catalog;

public sealed class Operation : IEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Guid Id { get; set; }
}