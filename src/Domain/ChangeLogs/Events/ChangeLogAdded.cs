using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ChangeLogs.Events;

public sealed record ChangeLogAdded(
    Guid Id,
    string PropertyName,
    string PropertyNameOnClient,
    object? OldValue,
    object? NewValue) : IDomainEvent;