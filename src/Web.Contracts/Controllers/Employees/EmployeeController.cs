using Forpost.Business.Abstract.Services;
using Forpost.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Forpost.Web.Contracts;

[ApiController]
[Route("api/v1/employees")]
[Authorize]
sealed public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    /// <summary>
    /// Получить список всех сотрудников
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(employees);
    }
}