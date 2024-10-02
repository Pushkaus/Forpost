using AutoMapper;
using Forpost.Application.Contracts.StorageManagment;
using Forpost.Features.StorageManagment.StorageProducts;
using Forpost.Web.Contracts.StorageManagement.StorageProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.StorageProduct;

[Route("api/v1/storage-products")]
public sealed class StorageProductController : ApiController
{
    /// <summary>
    /// Получить список всех продуктов на складе
    /// </summary>
    /// <returns></returns>
    [HttpGet("{storageId}", Name = "GetAllStorageProducts")]
    [ProducesResponseType(typeof(IReadOnlyCollection<StorageProductModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProductsAsync(Guid storageId, CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100)
    {
        var result = await Sender.Send(new GetProductsOnStorageQuery(storageId, skip, limit), cancellationToken);
        return Ok(new { Products = result.Products, TotalCount = result.TotalCount });
    }

    /// <summary>
    /// Добавить продукт на склад
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateStorageProduct")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] StorageProductCreateRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new AddProducOnStorageCommand(request.StorageId, request.ProductId, request.Quantity),
            cancellationToken);
        return Ok();
    }
}