using Forpost.Features.Catalogs.Employees;
using Forpost.Web.Contracts.Catalogs.Empoyees;
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
    [ProducesResponseType(typeof((IReadOnlyCollection<EmployeeResponse> Employees, int TotalCount)),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100,
        [FromQuery] string? filterExpression = null, [FromQuery] string?[]? filterValues = null)
    {
        var result = await Sender.Send(new GetAllEmployeesWithRoleQuery(filterExpression, filterValues, skip, limit),
            cancellationToken);
        return Ok(new
        {
            Employees = Mapper.Map<IReadOnlyCollection<EmployeeResponse>>(result.Employees),
            TotalCount = result.TotalCount
        });
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
}