using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.Roles;

public interface IRoleDomainRepository : IDomainRepository<Role>
{
    public Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken);
}