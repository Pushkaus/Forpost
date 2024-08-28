using AutoMapper;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

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
        return DbContext.Employees.Where(e => e.FirstName == firstName && e.LastName == lastName)
            .FirstOrDefaultAsync(cancellationToken);
    }
}