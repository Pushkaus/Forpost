using Forpost.Application.Contracts.Issues;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class IssueReadRepository: IIssueReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public IssueReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<IssueFromManufacturingProcess>> GetAllFromManufacturingProcessId(Guid manufacturingProcessId,
        CancellationToken cancellationToken)
    {
        return _dbContext.Issues.Where(i => i.ManufacturingProcessId == manufacturingProcessId)
            .Join(_dbContext.Steps,
                issue => issue.StepId,
                step => step.Id,
                (issue, step) => new
                {
                    Issue = issue,
                    Step = step
                })
            .Join(_dbContext.Operations,
                combined => combined.Step.OperationId,
                operation => operation.Id,
                (combined, operation) => new IssueFromManufacturingProcess
                {
                    Id = combined.Issue.Id,
                    OperationName = operation.Name,
                    ExecutorId = combined.Issue.ExecutorId,
                    ResponsibleId = combined.Issue.ResponsibleId,
                    Description = combined.Issue.Description,
                    CurrentQuantity = combined.Issue.CurrentQuantity,
                    Status = (IssueStatusModel)combined.Issue.IssueStatus,
                    StartTime = combined.Issue.StartTime,
                    EndTime = combined.Issue.EndTime,
                }
            ).ToListAsync(cancellationToken);
    }
}