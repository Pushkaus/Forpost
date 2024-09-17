using AutoMapper;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class IssueDomainRepository : DomainRepository<Issue>, IIssueDomainRepository
{
    
    public IssueDomainRepository(
        ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IMapper mapper)
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
        return await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(
                entity => entity.ManufacturingProcessId == manufacturingProcessId 
                          && entity.IssueNumber == 1, 
                cancellationToken
            );
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

    public async Task<IReadOnlyCollection<Issue>> GetIssuesByExecutorId(Guid executorId, CancellationToken cancellationToken) 
        => await DbContext.Issues.Where(entity => entity.ExecutorId == executorId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyCollection<Issue>> GetIssuesByResponsibleId(Guid responsibleId, CancellationToken cancellationToken) 
        => await DbContext.Issues.Where(entity => entity.ResponsibleId == responsibleId).ToListAsync(cancellationToken);
}