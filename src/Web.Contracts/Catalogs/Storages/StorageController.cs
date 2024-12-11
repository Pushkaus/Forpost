using Forpost.Application.Contracts.StorageManagement;
using Forpost.Features.Catalogs.Storages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Storages;

[Route("api/v1/storages")]
public sealed class StorageController : ApiController
{
    /// <summary>
    /// Создание нового склада
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] StorageCreateRequest request,
        CancellationToken cancellationToken)
    {
        var storageId =
            await Sender.Send(new AddStorageCommand(request.Name, request.ResponsibleId), cancellationToken);
        return Ok(storageId);
    }

    /// <summary>
    /// Получить список всех складов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<StorageModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllStoragesQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление информации о складе
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] StorageCreateRequest request,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new UpdateStorageCommand(id, request.Name, request.ResponsibleId),
            cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Удаление склада
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteStorageCommand(id), cancellationToken);

        return NoContent();
    }
}