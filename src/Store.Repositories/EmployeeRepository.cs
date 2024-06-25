using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class EmployeeRepository: IEmployeeRepository
{
    private readonly ForpostContextPostgres _db;

    public EmployeeRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public Task<List<Employee>> GetAllEmployeesAsync()
    {
        try
        {
            var employees = _db.Employees.ToListAsync();
            return employees;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}