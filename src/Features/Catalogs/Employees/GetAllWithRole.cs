using Forpost.Application.Contracts.Catalogs.Employees;
using Mediator;

namespace Forpost.Features.Catalogs.Employees;

internal sealed class GetAllEmployeesWithRoleQueryHandler :
    IQueryHandler<GetAllEmployeesWithRoleQuery, (IReadOnlyCollection<EmployeeWithRoleModel> Employees, int TotalCount)>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetAllEmployeesWithRoleQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<EmployeeWithRoleModel> Employees, int TotalCount)> Handle(
        GetAllEmployeesWithRoleQuery request,
        CancellationToken cancellationToken) =>
        await _employeeReadRepository.GetAllEmployeesWithRoleAsync(request.FilterExpression, request.FilterValues,
            request.Skip, request.Limit, cancellationToken);
}

public sealed record GetAllEmployeesWithRoleQuery(
    string? FilterExpression,
    object?[]? FilterValues,
    int Skip,
    int Limit) : IQuery<(IReadOnlyCollection<EmployeeWithRoleModel> Employees, int TotalCount)>;