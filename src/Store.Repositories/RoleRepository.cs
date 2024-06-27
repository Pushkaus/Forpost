using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var role = new Role(name);
            await _db.Roles.AddAsync(role);
            await _db.SaveChangesAsync(cancellationToken);
            return new OkResult();
        }
        catch (Exception ex)
        {
            return new BadRequestResult();
        }
    }

    public async Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken)
    {
        try
        {
            var roles = await _db.Roles.ToListAsync(cancellationToken);
            return roles;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<IActionResult> UpdateRoleAsync(string newName, string oldName, CancellationToken cancellationToken)
    {
        try
        {
            var roleToUpdate = await _db.Roles.FirstOrDefaultAsync(r => r.Name == oldName, cancellationToken);
            if (roleToUpdate == null)
            {
                return new NotFoundResult();
            }

            roleToUpdate.Name = newName;
            _db.Roles.Update(roleToUpdate);
            await _db.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
        catch (Exception ex)
        {
            return new BadRequestResult();
        }
    }

    public async Task<IActionResult> DeleteRoleAsync(string newName, CancellationToken cancellationToken)
    {
        try
        {
            var roleToDelete = await _db.Roles.FirstOrDefaultAsync(r => r.Name == newName, cancellationToken);
            if (roleToDelete == null)
            {
                return new NotFoundResult();
            }

            _db.Roles.Remove(roleToDelete);
            await _db.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
        catch (Exception ex)
        {
            return new BadRequestResult();
        }
    }
}