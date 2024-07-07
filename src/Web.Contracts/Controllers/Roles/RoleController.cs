using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
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
    [HttpPut("add-role")]
    public async Task<IActionResult> AddRoleAsync(string name, CancellationToken cancellationToken)
    {
        var result = await _roleService.AddRoleAsync(name, cancellationToken);
        return new OkResult();
    }

    [HttpGet("get-roles")]
    public async Task<IActionResult> GetRolesAsync(CancellationToken cancellationToken)
    {
        var result = await _roleService.GetRolesAsync(cancellationToken);
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Удаление роли по имени
    /// </summary>
    [HttpDelete("delete-role")]
    public async Task<IActionResult> DeleteRoleAsync(string newName, CancellationToken cancellationToken)
    {
        var result = await _roleService.DeleteRoleAsync(newName, cancellationToken);
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Обновление роли по имени
    /// </summary>
    [HttpPut("update-role")]
    public async Task<IActionResult> UpdateRoleAsync(string newName,string oldName, CancellationToken cancellationToken)
    {
        var result = await _roleService.UpdateRoleAsync(newName, oldName, cancellationToken);
        return new OkObjectResult(result);
    }

}