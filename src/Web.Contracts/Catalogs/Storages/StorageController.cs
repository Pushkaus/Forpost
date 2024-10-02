using Forpost.Domain.Catalogs.Storages;
using Forpost.Features.Catalogs.Storages;
using Forpost.Web.Contracts.StorageManagement.StorageProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Storages;

[Route("api/v1/storages")]
public sealed class StorageController : ApiController
{
    /// <summary>
    /// Создание нового склада
    /// </summary>
    /// <param name="request"></param>
    [HttpPost(Name = "CreateStorage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        CreateAsync([FromBody] StorageCreateRequest request, CancellationToken cancellationToken)
    {
        var storageId = await Sender.Send(new AddStorageCommand(request.Name, request.ResponsibleId), cancellationToken);
        return Ok(storageId);
    }

    /// <summary>
    /// Получить список всех складов
    /// </summary>
    /// <returns>Список складов и общее количество</returns>
    [HttpGet(Name = "GetAllStorages")]
    [ProducesResponseType(typeof(IReadOnlyCollection<Storage>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllStoragesQuery(), cancellationToken);
        return Ok(new
        {
            result.Storages,
            result.TotalCount
        });
    }
}
