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
    /// Создать новую роль
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        await _roleService.Add(name);
        return Ok();
    }

    /// <summary>
    /// Получить все роли
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _roleService.GetAll();
        return Ok(roles);
    }
}