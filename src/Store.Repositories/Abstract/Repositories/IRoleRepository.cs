using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IRoleRepository
{
    public Task<IActionResult> AddRoleAsync(string name, CancellationToken cancellationToken);
    public Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken);
    public Task<IActionResult> UpdateRoleAsync(string newName, string oldName, CancellationToken cancellationToken);

    public Task<IActionResult> DeleteRoleAsync(string newName, CancellationToken cancellationToken);

}