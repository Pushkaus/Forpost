using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Employees;

/// <summary>
/// Репозиторий для сотрудников
/// </summary>
public interface IEmployeeReadRepository : IApplicationReadRepository
{
    public Task<EntityPagedResult<EmployeeWithRoleModel>> GetAllEmployeesWithRoleAsync(EmployeeFilter filter,
        CancellationToken cancellationToken);
}