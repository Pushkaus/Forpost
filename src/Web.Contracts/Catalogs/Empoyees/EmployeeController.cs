using Forpost.Features.Catalogs.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Empoyees;

[Route("api/v1/employees")]
public sealed class EmployeeController : ApiController
{
    /// <summary>
    /// Получить список всех сотрудников
    /// </summary>
    /// <returns>Список сотрудников и общее количество</returns>
    [HttpGet(Name = "GetAllEmployees")]
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
}