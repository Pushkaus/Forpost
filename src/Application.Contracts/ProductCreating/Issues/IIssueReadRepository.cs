using Forpost.Application.Contracts.ProductCreating.Issues;
using Forpost.Common.DataAccess;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Application.Contracts.Issues;

public interface IIssueReadRepository: IApplicationReadRepository
{
    public Task<List<IssueFromManufacturingProcess>> GetAllFromManufacturingProcessId(Guid manufacturingProcessId,
        CancellationToken cancellationToken);
}