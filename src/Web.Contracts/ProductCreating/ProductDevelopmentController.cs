using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Application.ProductCreating.ProductsDevelopments;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductCreating;
[Route("api/v1/product-development")]
public sealed class ProductDevelopmentController: ApiController
{
    /// <summary>
    /// Генерация партии продуктов в разработке при старте производственного процесса
    /// </summary>
    /// <param name="manufacturingProcessId"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    public async Task<IActionResult> InitialInizializationAsync(Guid manufacturingProcessId,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(new BatchProductionInitializedCommand(manufacturingProcessId), cancellationToken);
        return Ok();
    }

    [HttpPut("{id}/assign-setting-option")]
    public async Task<IActionResult> AssignSettingOption(Guid productDevelopmentId, SettingOption settingOption,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(new AssignSettingOptionCommand(productDevelopmentId, settingOption), cancellationToken);
        return Ok();
    }
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductDevelopment>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<ProductDevelopment>> GetAllAsync(CancellationToken cancellationToken) 
        => await Mediator.Send(new GetAllQuery(), cancellationToken);
    [HttpGet("{productDevelopmentId}")]
    [ProducesResponseType(typeof(LocationDeterminationProductModel), StatusCodes.Status200OK)]
    public async Task<LocationDeterminationProductModel> GetLocation(Guid productDevelopmentId, CancellationToken cancellationToken)
    {
        var model = await Mediator.Send(new LocationDeterminationProductQuery(productDevelopmentId), cancellationToken);
        return Mapper.Map<LocationDeterminationProductModel>(model);
    }
}