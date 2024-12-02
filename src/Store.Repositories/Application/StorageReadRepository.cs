using Forpost.Application.Contracts.StorageManagement;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class StorageReadRepository : IStorageReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public StorageReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<StorageModel>> GetAllStorage(CancellationToken cancellationToken)
    {
        return await _dbContext.Storages
            .NotDeletedAt()
            .Join(_dbContext.Employees,
                storage => storage.ResponsibleId,
                employee => employee.Id,
                (storage, employee) => new StorageModel
                {
                    StorageId = storage.Id,
                    StorageName = storage.Name,
                    ResponsibleId = storage.ResponsibleId,
                    ResponsibleName = employee.FirstName + " " + employee.LastName,
                }).ToListAsync(cancellationToken);
    }
}