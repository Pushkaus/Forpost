using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IEmployeeRepository: IRepository<Employee>
{
    public Task<Employee?> GetAutorizedByUsername(string firstName, string lastName);
}