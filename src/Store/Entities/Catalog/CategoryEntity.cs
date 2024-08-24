using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities.Catalog;
//TODO; 
public sealed class CategoryEntity : IEntity
{
    public string Name { get; set; } = null!;
    public Guid? ParentId { get; set; }
    public Guid Id { get; set; }
}