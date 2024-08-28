using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Issues;

public interface IIssueReadRepository: IApplicationReadRepository
{
    public Task<List<IssueFromManufacturingProcess>> GetAllFromManufacturingProcessId(Guid manufacturingProcessId,
        CancellationToken cancellationToken);
}