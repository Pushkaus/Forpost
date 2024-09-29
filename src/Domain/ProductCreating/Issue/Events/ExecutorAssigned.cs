using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ProductCreating.Issue.Events;

public sealed record ExecutorAssigned(Guid ExecutorId, Guid IssueId): IDomainEvent
{
    
}