using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.Contractors;

public interface IContractorService : IBusinessService
{
    public Task<Guid> AddAsync(string name, CancellationToken cancellationToken);
    public Task<IReadOnlyList<ContractorEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<ContractorEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}