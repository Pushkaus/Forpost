using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Contractors;

public interface IContractorReadRepository : IApplicationReadRepository
{
    public Task<EntityPagedResult<ContractorModel>> GetAllAsync(ContractorFilter filter,
        CancellationToken cancellationToken);
    
    public Task<ContractorModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}