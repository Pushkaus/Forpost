using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.Roles;

public interface IRoleService : IBusinessService
{
    public Task AddAsync(string name, CancellationToken cancellationToken);
    public Task<IReadOnlyList<RoleEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<RoleEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}