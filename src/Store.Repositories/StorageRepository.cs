using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories;

public class StorageRepository: IStorageRepository
{
    private readonly ForpostContextPostgres _db;

    public StorageRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public async Task<IActionResult> CreateStorageAsync(string storageName, Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var storage = new Storage(storageName, userId);
            await _db.Storages.AddAsync(storage, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return new OkResult();
        }
        catch (Exception ex)
        {
            throw new Exception($"Произошла ошибка при добавлении склада: {ex.Message}");
        }
    }
}