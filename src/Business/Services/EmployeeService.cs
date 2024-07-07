using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Services;

public class EmployeeService: IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<IReadOnlyList<Employee>> GetAllAsync()
    {
       var employees = await _employeeRepository.GetAllAsync();
       return employees;
    }
}