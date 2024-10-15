using AutoMapper;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.StorageManagment;

internal sealed class StorageDomainRepository : DomainRepository<Storage>, IStorageDomainRepository
{
    public StorageDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}