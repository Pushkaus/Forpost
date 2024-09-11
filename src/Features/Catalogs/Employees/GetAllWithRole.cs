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

    public async ValueTask<(IReadOnlyCollection<EmployeeWithRoleModel> Employees, int TotalCount)> Handle(GetAllEmployeesWithRoleQuery request,
        CancellationToken cancellationToken) =>
        await _employeeReadRepository.GetAllEmployeesWithRoleAsync(cancellationToken, request.Skip, request.Limit);
}

// Запрос для получения всех сотрудников с их ролями
public sealed record GetAllEmployeesWithRoleQuery(int Skip, int Limit) : IQuery<(IReadOnlyCollection<EmployeeWithRoleModel> Employees, int TotalCount)>;