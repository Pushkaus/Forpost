using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IEmployeeService: IBusinessService
{
    public Task<List<Employee>> GetAllEmployeesAsync();
}