using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities.Catalog;

public sealed class Role : IEntity
{
    public string Name { get; set; } = null!;
    public Guid Id { get; set; }
}