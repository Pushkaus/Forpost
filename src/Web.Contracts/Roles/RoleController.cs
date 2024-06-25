using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts;
[ApiController]
[Route("api/v1/role")]
public class RoleController: ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    /// <summary>
    /// Добавить новую роль
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> AddRoleAsync(string name, CancellationToken cancellationToken)
    {
        var result = await _roleService.AddRoleAsync(name, cancellationToken);
        return new OkResult();
    }

}