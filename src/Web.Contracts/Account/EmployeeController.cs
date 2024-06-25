using Forpost.Business.Abstract.Services;
using Forpost.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Forpost.Web.Contracts;

[ApiController]
[Route("api/v1/Employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    /// <summary>
    /// Получить список всех сотрудников
    /// </summary>
    [HttpGet ("get-all-employee")]
    public async Task<IActionResult> GetAllEmployeesAsync()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }
}