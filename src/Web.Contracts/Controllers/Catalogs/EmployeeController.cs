using Forpost.Application.Catalogs.Employees;
using Forpost.Web.Contracts.Models.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Catalogs;

[Route("api/v1/employees")]
public sealed class EmployeeController : ApiController
{
    /// <summary>
    /// Получить список всех сотрудников
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<EmployeeResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
       var employees = await Mediator.Send(new GetAllEmployeesWithRoleQuery(), cancellationToken);
       return Ok(employees);
    }
}