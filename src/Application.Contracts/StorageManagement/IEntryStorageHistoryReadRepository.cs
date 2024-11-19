using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.StorageManagement;

public interface IEntryStorageHistoryReadRepository : IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<EntryStorageHistoryModel> Entries, int TotalCount)>
        GetAllEntries(EntryStorageHistoryFilter filter, CancellationToken cancellationToken);
}