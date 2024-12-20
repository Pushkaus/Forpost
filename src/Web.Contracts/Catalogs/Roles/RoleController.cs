using Forpost.Domain.Catalogs.Roles;
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
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] string name, CancellationToken cancellationToken)
    {
        var roleId = await Sender.Send(new AddRoleCommand(name), cancellationToken);
        return Ok(roleId);
    }

    /// <summary>
    /// Получить все роли
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Role>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllRolesQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить роль по id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await Sender.Send(new GetRoleByIdQuery(id), cancellationToken);
        return Ok(role);
    }
}