namespace Forpost.Common.EntityAnnotations;

public interface IAuditableEntity
{
    DateTimeOffset CreatedAt { get; set; }
    Guid CreatedById { get; set; }
    DateTimeOffset UpdatedAt { get; set; }
    Guid UpdatedById { get; set; }
    DateTimeOffset? DeletedAt { get; set; }
    Guid? DeletedById { get; set; }
}