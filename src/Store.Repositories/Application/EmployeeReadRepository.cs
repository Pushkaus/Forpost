using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using AutoMapper;
using Forpost.Application.Contracts;
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

    public async Task<EntityPagedResult<EmployeeWithRoleModel>> GetAllEmployeesWithRoleAsync(
        EmployeeFilter filter,
        CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.Employees.CountAsync(cancellationToken);

        var query = _dbContext.Employees.NotDeletedAt().OrderByDescending(x => x.UpdatedAt)
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
                    RoleId = employee.RoleId,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                }
            );
        if (!string.IsNullOrWhiteSpace(filter.Lastname))
        {
            query = query.Where(x => x.LastName.Contains(filter.Lastname));
        }

        var employees = await query
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<EmployeeWithRoleModel>
        {
            Items = employees,
            TotalCount = totalCount
        };
    }
}