using AutoMapper;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class EmployeeReadRepository : IEmployeeReadRepository
{
    private readonly ForpostContextPostgres _dbContext;
    public EmployeeReadRepository(ForpostContextPostgres dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<EmployeeWithRoleModel>> GetAllEmployeesWithRoleAsync(CancellationToken cancellationToken)
    {
        var usersWithRole = await _dbContext.Employees
            .Join(
                _dbContext.Roles,
                employee => employee.RoleId,
                role => role.Id,
                (employee, role) => new EmployeeWithRoleModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Patronymic = employee.Patronymic,
                    Post = employee.Post,
                    Role = role.Name,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                }
            )
            .ToListAsync(cancellationToken);

        return usersWithRole;
    }
}