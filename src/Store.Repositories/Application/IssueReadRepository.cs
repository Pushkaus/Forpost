using Forpost.Application.Contracts.Issues;
using Forpost.Application.Contracts.ProductCreating.Issues;
using Forpost.Domain.ProductCreating.Issue;
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

    public Task<List<IssueFromManufacturingProcessModel>> GetAllFromManufacturingProcessId(Guid manufacturingProcessId,
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
                (combined, operation) => new IssueFromManufacturingProcessModel
                {
                    Id = combined.Issue.Id,
                    OperationName = operation.Name,
                    IssueNumber = combined.Issue.IssueNumber,
                    ExecutorId = combined.Issue.ExecutorId,
                    ResponsibleId = combined.Issue.ResponsibleId,
                    Description = combined.Issue.Description,
                    CurrentQuantity = combined.Issue.CurrentQuantity,
                    Status = (IssueStatusModel)combined.Issue.IssueStatus.Value,
                    StartTime = combined.Issue.StartTime,
                    EndTime = combined.Issue.EndTime,
                    ProductCompositionFlag = combined.Issue.ProductCompositionSettingFlag
                }
            ).ToListAsync(cancellationToken);
    }

    public async Task<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)>
        GetIssuesByExecutorId(Guid executorId, CancellationToken cancellationToken, int skip, int limit)
    {
        var issues = await _dbContext.Issues.Where(i => i.ExecutorId == executorId 
                                                        && i.IssueStatus != IssueStatus.Completed)
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
                (combined, operation) => new { combined, operation })
            .Join(_dbContext.ManufacturingProcesses,
                combined => combined.combined.Issue.ManufacturingProcessId,
                manufacturingProcess => manufacturingProcess.Id,
                (combined, manufacturingProcess) => new { combined, manufacturingProcess })
            .Join(_dbContext.TechCards,
                combined => combined.manufacturingProcess.TechnologicalCardId,
                techCard => techCard.Id,
                (combined, techCard) => new { combined, techCard })
            .Join(_dbContext.Products,
                combined => combined.techCard.ProductId,
                product => product.Id,
                (combined, product) => new { combined, product })
            .Join(_dbContext.Employees,
                combined => combined.combined.combined.combined.combined.Issue.ExecutorId,
                executor => executor.Id,
                (combined, executor) => new { combined, executor })
            .Join(_dbContext.Employees,
                combined => combined.combined.combined.combined.combined.combined.Issue.ResponsibleId,
                responsible => responsible.Id,
                (combined, responsible) => new IssueModel
                {
                    Id = combined.combined.combined.combined.combined.combined.Issue.Id,
                    ProductName = combined.combined.product.Name,
                    OperationName = combined.combined.combined.combined.combined.operation.Name,
                    IssueNumber = combined.combined.combined.combined.combined.combined.Issue.IssueNumber,
                    ExecutorId = combined.combined.combined.combined.combined.combined.Issue.ExecutorId,
                    ExecutorName = combined.executor.FirstName + " " + combined.executor.LastName,
                    ResponsibleId = combined.combined.combined.combined.combined.combined.Issue.ResponsibleId,
                    ResponsibleName = responsible.FirstName + " " + responsible.LastName,
                    Description = combined.combined.combined.combined.combined.combined.Issue.Description,
                    CurrentQuantity = combined.combined.combined.combined.combined.combined.Issue.CurrentQuantity,
                    StartTime = combined.combined.combined.combined.combined.combined.Issue.StartTime,
                    EndTime = combined.combined.combined.combined.combined.combined.Issue.EndTime,
                    ProductCompositionFlag = combined.combined.combined.combined.combined.combined.Issue.ProductCompositionSettingFlag
                })
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);
        var totalCount = issues.Count();
        return (issues, totalCount);
    }

    public async Task<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)>
        GetIssuesByResponsibleId(Guid responsibleId, CancellationToken cancellationToken, int skip, int limit)
    {
        var issues = await _dbContext.Issues.Where(i => i.ResponsibleId == responsibleId 
                                                        && i.IssueStatus != IssueStatus.Completed)
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
                (combined, operation) => new { combined, operation })
            .Join(_dbContext.ManufacturingProcesses,
                combined => combined.combined.Issue.ManufacturingProcessId,
                manufacturingProcess => manufacturingProcess.Id,
                (combined, manufacturingProcess) => new { combined, manufacturingProcess })
            .Join(_dbContext.TechCards,
                combined => combined.manufacturingProcess.TechnologicalCardId,
                techCard => techCard.Id,
                (combined, techCard) => new { combined, techCard })
            .Join(_dbContext.Products,
                combined => combined.techCard.ProductId,
                product => product.Id,
                (combined, product) => new { combined, product })
            .Join(_dbContext.Employees,
                combined => combined.combined.combined.combined.combined.Issue.ExecutorId,
                executor => executor.Id,
                (combined, executor) => new { combined, executor })
            .Join(_dbContext.Employees,
                combined => combined.combined.combined.combined.combined.combined.Issue.ResponsibleId,
                responsible => responsible.Id,
                (combined, responsible) => new IssueModel
                {
                    Id = combined.combined.combined.combined.combined.combined.Issue.Id,
                    ProductName = combined.combined.product.Name,
                    OperationName = combined.combined.combined.combined.combined.operation.Name,
                    IssueNumber = combined.combined.combined.combined.combined.combined.Issue.IssueNumber,
                    ExecutorId = combined.combined.combined.combined.combined.combined.Issue.ExecutorId,
                    ExecutorName = combined.executor.FirstName + " " + combined.executor.LastName,
                    ResponsibleId = combined.combined.combined.combined.combined.combined.Issue.ResponsibleId,
                    ResponsibleName = responsible.FirstName + " " + responsible.LastName,
                    Description = combined.combined.combined.combined.combined.combined.Issue.Description,
                    CurrentQuantity = combined.combined.combined.combined.combined.combined.Issue.CurrentQuantity,
                    StartTime = combined.combined.combined.combined.combined.combined.Issue.StartTime,
                    EndTime = combined.combined.combined.combined.combined.combined.Issue.EndTime,
                    ProductCompositionFlag = combined.combined.combined.combined.combined.combined.Issue.ProductCompositionSettingFlag
                })
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);
        var totalCount = issues.Count();
        return (issues, totalCount);
    }
}