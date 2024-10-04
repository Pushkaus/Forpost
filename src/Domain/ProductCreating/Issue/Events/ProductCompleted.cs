using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ProductCreating.Issue.Events;

public sealed record ProductCompleted(Guid ProductDevelopmentId, Guid IssueId, Guid ExecutorId, Guid ResponsibleId)
    : IDomainEvent
{
}