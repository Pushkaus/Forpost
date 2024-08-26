namespace Forpost.Domain.ProductCreating.Issue;

public enum IssueStatusModel
{
    Pending = 100,
    PendingPreviousIssue = 101,
    InProgress = 200,
    Completed = 300,
    Cancelled = 400
}