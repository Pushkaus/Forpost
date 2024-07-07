using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class RoleRepository: Repository<Role>, IRoleRepository
{
    public RoleRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<Role?> GetByNameAsync(string name) 
        => await DbSet.FirstOrDefaultAsync(sp => sp.Name == name);
}