using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Services;

public sealed class RoleService: IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<IActionResult> AddRoleAsync(string name, CancellationToken cancellationToken)
    {
        var result = await _roleRepository.AddRoleAsync(name, cancellationToken);
        return result;
    }

    public Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken)
    {
        var result = _roleRepository.GetRolesAsync(cancellationToken);
        return result;
    }

    public Task<IActionResult> UpdateRoleAsync(string newName, string oldName, CancellationToken cancellationToken)
    {
        var result = _roleRepository.UpdateRoleAsync(newName, oldName, cancellationToken);
        return result;
    }

    public Task<IActionResult> DeleteRoleAsync(string newName, CancellationToken cancellationToken)
    {
        var result = _roleRepository.DeleteRoleAsync(newName, cancellationToken);
        return result;
    }
}