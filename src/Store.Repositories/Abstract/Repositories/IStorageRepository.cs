using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageRepository
{
    public Task<string> CreateStorageAsync(string storageName, Guid userId, Guid responsibleId, CancellationToken cancellationToken);
}