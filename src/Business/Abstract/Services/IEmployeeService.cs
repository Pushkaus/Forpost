using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IEmployeeService : IBusinessService
{
    public Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken);
}