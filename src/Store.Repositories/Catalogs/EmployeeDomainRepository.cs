using AutoMapper;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class EmployeeDomainRepository : DomainRepository<Employee>, IEmployeeDomainRepository
{
    public EmployeeDomainRepository(ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IMapper mapper) : base(
        dbContext, timeProvider, mapper)
    {
    }

    public async Task<Employee?> GetAuthorizedByUsernameAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        return await DbContext.Employees.Where(e => e.FirstName == firstName && e.LastName == lastName)
            .FirstOrDefaultAsync(cancellationToken);
    }
}