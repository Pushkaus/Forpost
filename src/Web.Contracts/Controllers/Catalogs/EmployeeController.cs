// using Forpost.Domain.Catalogs.Employees;
// using Forpost.Web.Contracts.Models.Employees;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Forpost.Web.Contracts.Controllers.Catalogs.Employees;
//
// [ApiController]
// [Route("api/v1/employees")]
// public sealed class EmployeeController : ControllerBase
// {
//     private readonly IEmployeeService _employeeService;
//
//     public EmployeeController(IEmployeeService employeeService)
//     {
//         _employeeService = employeeService;
//     }
//
//     /// <summary>
//     /// Получить список всех сотрудников
//     /// </summary>
//     [HttpGet]
//     [ProducesResponseType(typeof(IReadOnlyCollection<EmployeeResponse>), StatusCodes.Status200OK)]
//     public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
//     {
//         var employees = await _employeeService.GetAllAsync(cancellationToken);
//         return Ok(employees);
//     }
// }