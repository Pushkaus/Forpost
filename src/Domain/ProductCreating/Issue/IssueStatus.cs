using Forpost.Common.DomainAbstractions;

namespace Forpost.Domain.ProductCreating.Issue;

public sealed class IssueStatus : SmartEnumeration<IssueStatus>
{
    public static readonly IssueStatus Pending = new(nameof(Pending), 100);
    public static readonly IssueStatus InProgress = new(nameof(InProgress), 200);
    public static readonly IssueStatus Completed = new(nameof(Completed), 300);
    public static readonly IssueStatus Cancelled = new(nameof(Cancelled), 400);
    
    private IssueStatus(string name, int value) : base(name, value) { }
}