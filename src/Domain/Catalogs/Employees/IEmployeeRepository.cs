using Forpost.Common.DataAccess;

namespace Forpost.Domain.Catalogs.Employees;

public interface IEmployeeRepository : IRepository<Employee>
{
    public Task<Employee?> GetAuthorizedByUsernameAsync(string firstName, string lastName,
        CancellationToken cancellationToken);
}