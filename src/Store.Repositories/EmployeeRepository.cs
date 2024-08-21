using AutoMapper;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<EmployeeWithRole?>
        GetAutorizedByUsernameAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        var userWithRole = await DbSet
            .Join(
                DbContext.Roles,
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
            .FirstOrDefaultAsync(e => e.FirstName == firstName && e.LastName == lastName, cancellationToken);

        return userWithRole;
    }
}