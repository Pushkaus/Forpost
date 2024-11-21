using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ChangeLogs.Events;

public sealed record ChangeLogAdded(ChangeLog ChangeLog): IDomainEvent
{
    
}