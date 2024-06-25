using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories;

public class RoleRepository: IRoleRepository
{
    private readonly ForpostContextPostgres _db;

    public RoleRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public async Task<IActionResult> AddRoleAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = name,
            };
            await _db.Roles.AddAsync(role);
            await _db.SaveChangesAsync(cancellationToken);
            return new OkResult();
        }
        catch (Exception ex)
        {
            return new BadRequestResult();
        }
    }
}