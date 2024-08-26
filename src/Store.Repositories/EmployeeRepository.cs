using AutoMapper;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IMapper mapper) : base(
        dbContext, timeProvider, mapper)
    {
    }

    public Task<Employee?> GetAuthorizedByUsernameAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}