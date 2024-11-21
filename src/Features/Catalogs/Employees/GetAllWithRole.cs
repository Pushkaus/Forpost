using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.Employees;
using Mediator;

namespace Forpost.Features.Catalogs.Employees;

internal sealed class GetAllEmployeesWithRoleQueryHandler :
    IQueryHandler<GetAllEmployeesWithRoleQuery, EntityPagedResult<EmployeeWithRoleModel>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetAllEmployeesWithRoleQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }

    public async ValueTask<EntityPagedResult<EmployeeWithRoleModel>> Handle(
        GetAllEmployeesWithRoleQuery request,
        CancellationToken cancellationToken) =>
        await _employeeReadRepository.GetAllEmployeesWithRoleAsync(request.Filter, cancellationToken);
}

public sealed record GetAllEmployeesWithRoleQuery(EmployeeFilter Filter)
    : IQuery<EntityPagedResult<EmployeeWithRoleModel>>;