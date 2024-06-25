using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IRoleRepository
{
    public Task<IActionResult> AddRoleAsync(string name, CancellationToken cancellationToken);
}