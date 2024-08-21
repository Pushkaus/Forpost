using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface IEmployeeService : IBusinessService
{
    public Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken);
}