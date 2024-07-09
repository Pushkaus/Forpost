using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Roles;
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

    /// <summary>
    /// Получить роль по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
       var role = await _roleService.GetById(id);
       return Ok(role);
    }
}