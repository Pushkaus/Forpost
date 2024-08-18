using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IContragentService : IBusinessService
{
    public Task AddAsync(string name, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Contractor>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Contractor?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}