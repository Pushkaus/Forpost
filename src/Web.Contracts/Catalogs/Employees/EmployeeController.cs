using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Features.Catalogs.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Employees;

[Route("api/v1/employees")]
public sealed class EmployeeController : ApiController
{
    /// <summary>
    /// Получить список всех сотрудников
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(EntityPagedResult<EmployeeWithRoleModel>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync([FromQuery] EmployeeFilter filter, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllEmployeesWithRoleQuery(filter),
            cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление информации о сотруднике
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] EmployeeRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(
            new UpdateEmployeeCommand(id, request.FirstName, request.LastName, request.Patronymic, request.Post,
                request.RoleId,
                request.Email, request.PhoneNumber),
            cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Удаление сотрудника
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteEmployeeCommand(id), cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Обновление пароля пользователя
    /// </summary>
    [HttpPut("{id:guid}/password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePassword(Guid id, [FromBody] UpdatePasswordRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new UpdatePasswordCommand(id, request.Password), cancellationToken);
        return NoContent();
    }
}