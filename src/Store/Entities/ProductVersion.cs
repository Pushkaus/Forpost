using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class ProductVersion: IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public Product Product { get; set; }
    
}