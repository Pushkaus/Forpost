using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public sealed class Category : IEntity
{
    public string Name { get; set; } = null!;
    public Guid? ParentId { get; set; }
    public Guid Id { get; set; }
}