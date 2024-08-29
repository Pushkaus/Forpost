using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.Employees;

public interface IEmployeeDomainRepository : IDomainRepository<Employee>
{
    public Task<Employee?> GetAuthorizedByUsernameAsync(string firstName, string lastName,
        CancellationToken cancellationToken);
}