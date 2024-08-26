using Forpost.Common.EntityAnnotations;

namespace Forpost.Common.EntityTemplates;

/// <summary>
/// Доменная сущность
/// </summary>
public abstract class DomainEntity : IEntity
{
    public Guid Id { get; }
}