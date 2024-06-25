using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IEmployeeRepository
{
    public Task<List<Employee>> GetAllEmployeesAsync();
}