using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IRoleService: IBusinessService
{
    public Task<IActionResult> AddRoleAsync(string name, CancellationToken cancellationToken);
    public Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken);
    public Task<IActionResult> UpdateRoleAsync(string newName, string oldName, CancellationToken cancellationToken);
    public Task<IActionResult> DeleteRoleAsync(string newName, CancellationToken cancellationToken);
}