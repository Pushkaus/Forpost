using Forpost.Application.Contracts.Catalogs.Employees;
using Mediator;

namespace Forpost.Features.Catalogs.Employees;

internal sealed class GetAllEmployeesWithRoleQueryHandler :
    IQueryHandler<GetAllEmployeesWithRoleQuery, IReadOnlyCollection<EmployeeWithRoleModel>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetAllEmployeesWithRoleQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<EmployeeWithRoleModel>> Handle(GetAllEmployeesWithRoleQuery request,
        CancellationToken cancellationToken) =>
        await _employeeReadRepository.GetAllEmployeesWithRoleAsync(cancellationToken);
}

public sealed record GetAllEmployeesWithRoleQuery : IQuery<IReadOnlyCollection<EmployeeWithRoleModel>>;

