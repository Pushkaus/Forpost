namespace Forpost.Common.EntityAnnotations;

public interface IAuditableEntity
{
    DateTimeOffset CreatedAt { get; }
    Guid CreatedById { get; }
    DateTimeOffset UpdatedAt { get; }
    Guid UpdatedById { get; }
    DateTimeOffset? DeletedAt { get; }
    Guid? DeletedById { get; }
}