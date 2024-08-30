using Forpost.Domain.Primitives.EntityAnnotations;

namespace Forpost.Domain.Primitives.EntityTemplates;

/// <summary>
/// Доменная сущность
/// </summary>
public abstract class DomainEntity : IEntity
{
    public Guid Id { get; set; }
}