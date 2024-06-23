using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public sealed class Assembly: IAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid StorageId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public ICollection<ProductAssembly> ProductAssemblies { get; set; }  // Коллекция связей с Products
    public Storage Storage;

}