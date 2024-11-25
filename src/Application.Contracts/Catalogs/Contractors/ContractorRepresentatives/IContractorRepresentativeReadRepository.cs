using Forpost.Common.DataAccess;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;

namespace Forpost.Application.Contracts.Catalogs.Contractors.ContractorRepresentatives;

public interface IContractorRepresentativeReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyCollection<ContractorRepresentative>> GetByContractorIdAsync(Guid contractorId,
        CancellationToken cancellationToken);
}