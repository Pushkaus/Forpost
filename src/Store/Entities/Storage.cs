using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public class Storage: IAuditableEntity
{
    private Storage() {}
    public Storage(string storageName, Guid userId)
    {
        Name = storageName;
        CreatedAt = DateTimeOffset.UtcNow;
        CreatedById = userId;
        UpdatedAt = DateTimeOffset.UtcNow;
        UpdatedById = userId;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Employee Employee { get; set; }
    public Guid ResponsibleId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public ICollection<StorageProduct> StorageProducts { get; set; }
}