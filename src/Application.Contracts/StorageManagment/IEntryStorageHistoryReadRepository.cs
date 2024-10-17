using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.StorageManagment;

public interface IEntryStorageHistoryReadRepository : IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<EntryStorageHistoryModel> Entries, int TotalCount)>
        GetAllEntries(EntryStorageHistoryFilter filter, CancellationToken cancellationToken);
}