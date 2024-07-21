using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class EmployeeRepository: Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<Employee?> GetAutorizedByUsername(string firstName, string lastName)
    { 
        var user = await DbSet.Include(x => x.Role)
            .FirstOrDefaultAsync(entity => entity.FirstName == firstName 
                                           && entity.LastName == lastName);

        return user;
    }
}