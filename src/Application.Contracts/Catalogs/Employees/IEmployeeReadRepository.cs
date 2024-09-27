using Forpost.Common.DataAccess;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Application.Contracts.Catalogs.Employees;

/// <summary>
/// Репозиторий для сотрудников
/// </summary>
public interface IEmployeeReadRepository : IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<EmployeeWithRoleModel> Employees, int TotalCount)> GetAllEmployeesWithRoleAsync(
        string? filterExpression, object?[]? filterValues, int skip, int limit, CancellationToken cancellationToken);
}