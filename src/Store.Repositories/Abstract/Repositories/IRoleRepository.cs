using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IRoleRepository: IRepository<Role>
{
    public Task<Role?> GetByNameAsync(string name);
}