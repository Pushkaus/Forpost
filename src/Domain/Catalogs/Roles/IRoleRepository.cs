using Forpost.Common.DataAccess;

namespace Forpost.Domain.Catalogs.Roles;

public interface IRoleRepository : IRepository<Role>
{
    public Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken);
}