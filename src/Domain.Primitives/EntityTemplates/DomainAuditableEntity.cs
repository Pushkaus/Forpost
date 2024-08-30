using Forpost.Domain.Primitives.EntityAnnotations;

namespace Forpost.Domain.Primitives.EntityTemplates;

/// <summary>
/// Доменная сущность с аудит-свойствами
/// </summary>
public abstract class DomainAuditableEntity : DomainEntity, IAuditableEntity
{
    public DateTimeOffset CreatedAt { get; private set; }
    public Guid CreatedById { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }
    public Guid UpdatedById { get; private set; }
    public DateTimeOffset? DeletedAt { get; private set; }
    public Guid? DeletedById { get; private set; }
}