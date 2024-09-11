using Forpost.Common.DataAccess;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Application.Contracts.Catalogs.Employees;

/// <summary>
/// Репозиторий для сотрудников
/// </summary>
public interface IEmployeeReadRepository : IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<EmployeeWithRoleModel> Employees, int TotalCount)>  GetAllEmployeesWithRoleAsync(
        CancellationToken cancellationToken, int skip = 0, int limit = 100);
}