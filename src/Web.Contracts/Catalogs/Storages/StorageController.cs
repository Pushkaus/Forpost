using Forpost.Application.Catalogs.Storages;
using Forpost.Domain.Catalogs.Storages;
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
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        CreateAsync([FromBody] StorageCreateRequest request, CancellationToken cancellationToken)
    {
        var storageId = Mediator.Send(new AddStorageCommand(request.Name, request.ResponsibleId), cancellationToken);
        return Ok(storageId);
    }

    /// <summary>
    /// Получить список всех складов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(StorageReponse), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<Storage>> GetAllAsync(CancellationToken cancellationToken) 
        => await Mediator.Send(new GetAllStoragesQuery(), cancellationToken);
}