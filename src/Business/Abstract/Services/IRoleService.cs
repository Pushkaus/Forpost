using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface IRoleService : IBusinessService
{
    public Task AddAsync(string name, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Role>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}