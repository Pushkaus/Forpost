using AutoMapper;
using Forpost.Domain.Catalogs.Roles;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class RoleDomainRepository : DomainRepository<Role>, IRoleDomainRepository
{
    public RoleDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await DbSet.FirstOrDefaultAsync(sp => sp.Name == name, cancellationToken);
    }
}