namespace Forpost.Application.Contracts.ProductCreating.Issues;

public enum IssueStatusModel
{
    Pending = 100,
    PendingPreviousIssue = 101,
    InProgress = 200,
    Completed = 300,
    Cancelled = 400
}