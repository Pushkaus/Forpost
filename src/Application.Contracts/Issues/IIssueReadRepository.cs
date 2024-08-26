using Forpost.Application.Contracts.Issues;
using Forpost.Common.DataAccess;

namespace Forpost.Domain.ProductCreating.Issue;

public interface IIssueReadRepository: IApplicationReadRepository
{
    public Task<List<IssueFromManufacturingProcess>> GetAllFromManufacturingProcessId(Guid manufacturingProcessId,
        CancellationToken cancellationToken);
}