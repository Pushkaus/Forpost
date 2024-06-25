using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IRoleService: IBusinessService
{
    public Task<IActionResult> AddRoleAsync(string name, CancellationToken cancellationToken);
}