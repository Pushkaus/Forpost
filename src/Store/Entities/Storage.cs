using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class Storage: IAuditableEntity, IEntity
{
    private Storage() {}
    public Storage(string storageName, Guid userId, Guid responsibleId)
    {
        Name = storageName;
        ResponsibleId = responsibleId;
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
    public IReadOnlyCollection<StorageProduct> StorageProducts { get; set; }
}