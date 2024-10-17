using AutoMapper;
using Forpost.Domain.StorageManagment.EntryStorageHistories;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.StorageManagment;

internal sealed class EntryStorageHistoryDomainRepository : DomainRepository<EntryStorageHistory>,
    IEntryStorageHistoryDomainRepository
{
    public EntryStorageHistoryDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider,
        IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
}