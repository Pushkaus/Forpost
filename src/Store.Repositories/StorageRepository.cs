using AutoMapper;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class StorageRepository : Repository<Storage>, IStorageRepository
{
    public StorageRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}