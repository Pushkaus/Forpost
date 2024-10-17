using Forpost.Application.Contracts.StorageManagment;
using Mediator;

namespace Forpost.Features.StorageManagement.EntryStorageHistories;

internal sealed class GetAllEntryStorageHistoriesQueryHandler : IQueryHandler<GetAllEntryStorageHistoriesQuery, (
    IReadOnlyCollection<EntryStorageHistoryModel> Entries, int TotalCount)>
{
    private readonly IEntryStorageHistoryReadRepository _entryStorageHistoryReadRepository;

    public GetAllEntryStorageHistoriesQueryHandler(IEntryStorageHistoryReadRepository entryStorageHistoryReadRepository)
    {
        _entryStorageHistoryReadRepository = entryStorageHistoryReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<EntryStorageHistoryModel> Entries, int TotalCount)> Handle(
        GetAllEntryStorageHistoriesQuery query, CancellationToken cancellationToken) =>
        await _entryStorageHistoryReadRepository.GetAllEntries(query.Filter, cancellationToken);
}

public record GetAllEntryStorageHistoriesQuery(EntryStorageHistoryFilter Filter)
    : IQuery<(IReadOnlyCollection<EntryStorageHistoryModel> Entries, int TotalCount)>;