namespace Forpost.Application.Contracts.CRM.IssueHistory;

public sealed class IssueHistoryModel
{
    public Guid ProductDevelopmentId { get; set; }
    public string ProductName { get; set; } = null!;
    public Guid IssueId { get; set; }
    public string OperationName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTimeOffset CompletionDate { get; set; }
    public Guid ExecutorId { get; set; }
    public string ExecutorName { get; set; } = null!;
    public Guid ResponsibleId { get; set; }
    public string ResponsibleName { get; set; } = null!;
}