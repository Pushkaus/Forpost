using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.Employees;

public interface IEmployeeService : IBusinessService
{
    public Task<IReadOnlyList<EmployeeEntity>> GetAllAsync(CancellationToken cancellationToken);
}