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

    public Task<List<IssueFromManufacturingProcessModel>> GetAllFromManufacturingProcessId(Guid manufacturingProcessId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)> GetIssuesByExecutorId(Guid executorId, CancellationToken cancellationToken, int skip, int limit)
    {
        throw new NotImplementedException();
    }

    public Task<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)> GetIssuesByResponsibleId(Guid responsibleId, CancellationToken cancellationToken, int skip, int limit)
    {
        throw new NotImplementedException();
    }

    public Task<IssueModel?> GetById(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}