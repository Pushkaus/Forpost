using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts.CRM.IssueHistories;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class IssueHistoryReadRepository : IIssueHistoryReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public IssueHistoryReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(IReadOnlyCollection<IssueHistoryModel> Issues, int TotalCount)> GetAll(IssueHistoryFilter filter,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.IssueHistories
            .Join(_dbContext.ProductDevelopments,
                issuesHistory => issuesHistory.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (issueHistory, productDevelopment) => new { issueHistory, productDevelopment })
            .Join(_dbContext.Products,
                combined => combined.productDevelopment.ProductId,
                product => product.Id,
                (combined, product) => new { combined, product })
            .Join(_dbContext.Issues,
                combined => combined.combined.issueHistory.IssueId,
                issue => issue.Id,
                (combined, issue) => new { combined, issue })
            .Join(_dbContext.Steps,
                combined => combined.issue.StepId,
                step => step.Id,
                (combined, step) => new { combined, step })
            .Join(_dbContext.Operations,
                combined => combined.step.OperationId,
                operation => operation.Id,
                (combined, operation) => new { combined, operation })
            .Join(_dbContext.Employees,
                combined => combined.combined.combined.combined.combined.issueHistory.ExecutorId,
                executor => executor.Id,
                (combined, executor) => new { combined, executor })
            .Join(_dbContext.Employees,
                combined => combined.combined.combined.combined.combined.combined.issueHistory.ResponsibleId,
                responsible => responsible.Id,
                (combined, responsible) => new IssueHistoryModel
                {
                    Id = combined.combined.combined.combined.combined.combined.issueHistory.Id,
                    ProductDevelopmentId = combined.combined.combined.combined.combined.combined.productDevelopment.Id,
                    ProductName = combined.combined.combined.combined.combined.product.Name,
                    SerialNumber = combined.combined.combined.combined.combined.combined.productDevelopment.SerialNumber,
                    IssueId = combined.combined.combined.combined.combined.combined.issueHistory.IssueId,
                    OperationName = combined.combined.operation.Name,
                    Description = combined.combined.combined.combined.combined.combined.issueHistory.Description,
                    CompletionDate = combined.combined.combined.combined.combined.combined.issueHistory.CompletionDate,
                    ExecutorId = combined.combined.combined.combined.combined.combined.issueHistory.ExecutorId,
                    ExecutorName = combined.executor.FirstName + " " + combined.executor.LastName,
                    ResponsibleId = combined.combined.combined.combined.combined.combined.issueHistory.ResponsibleId,
                    ResponsibleName = responsible.FirstName + " " + responsible.LastName,
                });
        if (filter.ExecutorId.HasValue)
        {
            query = query.Where(h => h.ExecutorId == filter.ExecutorId.Value);
        }

        if (filter.ResponsibleId.HasValue)
        {
            query = query.Where(h => h.ResponsibleId == filter.ResponsibleId.Value);
        }

        if (filter.Month.HasValue && filter.Year.HasValue)
        {
            query = query.Where(h => h.CompletionDate.Year == filter.Year.Value &&
                                     h.CompletionDate.Month == filter.Month.Value);
        }

        // Получаем общее количество записей
        var totalCount = await query.CountAsync(cancellationToken);

        // Применяем пагинацию и сортировку
        var issues = await query
            .OrderByDescending(c => c.CompletionDate)
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);

        return (issues.AsReadOnly(), totalCount);
    }
}