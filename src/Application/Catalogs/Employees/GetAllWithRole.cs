using Forpost.Application.Contracts.Catalogs.Employees;
using MediatR;

namespace Forpost.Application.Catalogs.Employees;

internal sealed class GetAllEmployeesWithRoleQueryHandler :
    IRequestHandler<GetAllEmployeesWithRoleQuery, IReadOnlyCollection<EmployeeWithRoleModel>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetAllEmployeesWithRoleQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }

    public async Task<IReadOnlyCollection<EmployeeWithRoleModel>> Handle(GetAllEmployeesWithRoleQuery request,
        CancellationToken cancellationToken) =>
        await _employeeReadRepository.GetAllEmployeesWithRoleAsync(cancellationToken);
}

public sealed record GetAllEmployeesWithRoleQuery : IRequest<IReadOnlyCollection<EmployeeWithRoleModel>>;

