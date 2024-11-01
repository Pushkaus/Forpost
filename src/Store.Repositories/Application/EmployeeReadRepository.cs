using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
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
    public async Task<(IReadOnlyCollection<EmployeeWithRoleModel> Employees, int TotalCount)> GetAllEmployeesWithRoleAsync(
        string? filterExpression, object?[]? filterValues, int skip, int limit,
        CancellationToken cancellationToken)
    {
        
        var totalCount = await _dbContext.Employees.CountAsync(cancellationToken);

        // Начинаем основной запрос с соединением таблиц
        var query = _dbContext.Employees
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

        // Применение фильтрации, если выражение задано
        if (!string.IsNullOrWhiteSpace(filterExpression))
        {
            try
            {
                query = query.Where($"{filterExpression}.Contains(@0)", filterValues);
            }
            catch (ParseException ex)
            {
                throw new ArgumentException("Некорректное выражение фильтрации.", ex);
            }
        }

        // Получаем отфильтрованный и разбитый на страницы список сотрудников
        var employees = await query
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);

        return (employees, totalCount);
    }
}