using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Crm.IssueHistory;

public sealed class IssueHistory: DomainEntity
{
    public Guid ProductDevelopmentId { get; set; }
    public Guid IssueId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CompletionDate { get; set; }
    public Guid ExecutorId { get; set; }
    public Guid ResponsibleId { get; set; }
}