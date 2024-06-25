using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public sealed class ProductWork: IAuditableEntity
{
    public Guid WorkTypeId { get; set; }
    public Guid ProductId { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public Product Product { get; set; }
    public WorkType WorkType { get; set; }
}