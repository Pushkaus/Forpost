using Forpost.Application.Contracts.StorageManagment;
using Forpost.Features.StorageManagement.EntryStorageHistories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.StorageManagement.EntryStorageHistories;

[Route("api/v1/entry-storage-histories")]
public sealed class EntryStorageHistoryController : ApiController
{
    /// <summary>
    /// Получение всех поступлений на склад
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof((IReadOnlyCollection<EntryStorageHistoryModel> Entries, int TotalCount)), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllEntries([FromQuery] EntryStorageHistoryFilter filter,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllEntryStorageHistoriesQuery(filter), cancellationToken);
        return Ok(new { Entries = result.Entries, TotalCount = result.TotalCount });
    }
}