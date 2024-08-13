using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IEmployeeRepository: IRepository<Employee>
{
    public Task<EmployeeWithRole?> 
        GetAutorizedByUsernameAsync(string firstName, string lastName, CancellationToken cancellationToken);
}