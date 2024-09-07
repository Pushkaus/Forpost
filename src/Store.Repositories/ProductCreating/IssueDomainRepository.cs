using AutoMapper;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class IssueDomainRepository : DomainRepository<Issue>, IIssueDomainRepository
{
    
    public IssueDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }


    public async Task<int> GetIssueNumber(Guid techCardId, Guid stepId, CancellationToken cancellationToken)
    {
        return await DbContext.TechCardSteps.Where(entity => entity.TechCardId == techCardId && entity.StepId == stepId)
            .Select(entity => entity.Number).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Issue?> GetFirstIssue(Guid manufacturingProcessId, CancellationToken cancellationToken)
    {
        return await DbContext.Issues
            .Where(entity => entity.ManufacturingProcessId == manufacturingProcessId)
            .Where(entity => entity.IssueNumber == 1)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Issue?> GetNextIssue(Guid issueId, CancellationToken cancellationToken)
    {
        var issue = await DbContext.Issues
            .Where(entity => entity.Id == issueId)
            .FirstOrDefaultAsync(cancellationToken);
        return await DbContext.Issues
            .Where(entity => entity.ManufacturingProcessId == issue.ManufacturingProcessId)
            .Where(entity => entity.IssueNumber == issue.IssueNumber + 1)
            .FirstOrDefaultAsync(cancellationToken);
    }
}