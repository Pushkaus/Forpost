using AutoMapper.QueryableExtensions;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class EmployeeRepository: Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ForpostContextPostgres db) : base(db)
    {
        
    }

    public async Task<EmployeeWithRole?> GetAutorizedByUsername(string firstName, string lastName)
    {
        var userWithRole = await DbSet
            .Join(
                _db.Roles,
                employee => employee.RoleId,
                role => role.Id,
                (employee, role) => new EmployeeWithRole
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Patronymic = employee.Patronymic,
                    Post = employee.Post,
                    Role = role.Name,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    PasswordHash = employee.PasswordHash
                }
            )
            .FirstOrDefaultAsync(e => e.FirstName == firstName && e.LastName == lastName);

        return userWithRole;
    }
}