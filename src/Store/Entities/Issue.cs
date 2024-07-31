using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public class Issue: IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ExecutorId { get; set; }
    public DateTimeOffset? DateCompletion { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Cost { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
}