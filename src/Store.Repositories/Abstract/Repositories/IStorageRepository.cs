using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageRepository
{
    public Task<IActionResult> CreateStorageAsync(string storageName, Guid userId, CancellationToken cancellationToken);
}