using Forpost.Common.DataAccess;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Application.Contracts.Catalogs.Employees;

/// <summary>
/// Репозиторий для сотрудников
/// </summary>
public interface IEmployeeReadRepository : IApplicationReadRepository
{
    public Task<EntityPagedResult<EmployeeWithRoleModel>> GetAllEmployeesWithRoleAsync(EmployeeFilter filter,
        CancellationToken cancellationToken);
}