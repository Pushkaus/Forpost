using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface IContragentService : IBusinessService
{
    public Task<Guid> AddAsync(string name, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Contractor>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Contractor?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}