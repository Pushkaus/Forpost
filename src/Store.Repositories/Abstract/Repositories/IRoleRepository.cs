using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IRoleRepository : IRepository<RoleEntity>
{
    public Task<RoleEntity?> GetByNameAsync(string name, CancellationToken cancellationToken);
}