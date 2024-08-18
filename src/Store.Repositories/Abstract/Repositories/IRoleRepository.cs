using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    public Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken);
}