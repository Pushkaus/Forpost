using Forpost.Business.Abstract.Services;
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
}