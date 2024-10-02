using Forpost.Features.Catalogs.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Roles;

[Route("api/v1/role")]
public sealed class RoleController : ApiController
{
    /// <summary>
    /// Создать новую роль
    /// </summary>
    [HttpPost("CreateRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] string name, CancellationToken cancellationToken)
    {
        var roleId = await Sender.Send(new AddRoleCommand(name), cancellationToken);
        return Ok(roleId);
    }

    /// <summary>
    /// Получить все роли
    /// </summary>
    [HttpGet(Name = "GetAllRoles")]
    [ProducesResponseType(typeof(IReadOnlyCollection<RoleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllRolesQuery(), cancellationToken);
        return Ok(result.Roles);
    }

    /// <summary>
    /// Получить роль по id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}", Name = "GetRoleById")]
    [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await Sender.Send(new GetRoleByIdQuery(id), cancellationToken);
        return Ok(role);
    }
}