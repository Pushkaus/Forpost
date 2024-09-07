using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ProductCreating.Issue;

public interface IIssueDomainRepository : IDomainRepository<Issue>
{
    public Task<int> GetIssueNumber(Guid techCardId, Guid stepId, CancellationToken cancellationToken);
    public Task<Issue?> GetFirstIssue(Guid manufacturingProcessId, CancellationToken cancellationToken);
    public Task<Issue?> GetNextIssue(Guid issueId, CancellationToken cancellationToken);
}