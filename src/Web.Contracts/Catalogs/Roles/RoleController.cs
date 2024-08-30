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
    public async Task<IActionResult> CreateAsync(string name, CancellationToken cancellationToken)
    {
        var roleId = await Mediator.Send(new AddRoleCommand(name), cancellationToken);
        return Ok(roleId);
    }

    /// <summary>
    /// Получить все роли
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<RoleResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var roles = await Mediator.Send(new GetAllRolesQuery(), cancellationToken);
        return Ok(roles);
    }

    /// <summary>
    /// Получить роль по id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await Mediator.Send(new GetRoleByIdQuery(id), cancellationToken);
        return Ok(role);
    }
}