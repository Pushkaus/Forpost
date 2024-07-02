using System.Collections;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class StorageRepository: IStorageRepository
{
    private readonly ForpostContextPostgres _db;

    public StorageRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public async Task<string> CreateStorageAsync(string storageName, Guid userId, Guid responsibleId, CancellationToken cancellationToken)
    {
        try
        {
            responsibleId = userId;
            var storage = new Storage(storageName, userId, responsibleId);
            await _db.Storages.AddAsync(storage, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return new string($"Создан новый склад {storageName}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Произошла ошибка при добавлении склада: {ex.Message}");
        }
    }
}