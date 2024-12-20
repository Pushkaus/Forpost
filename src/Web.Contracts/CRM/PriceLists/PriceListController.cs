using Forpost.Application.Contracts.CRM.PriceLists;
using Forpost.Features.CRM.PriceLists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Crm.PriceLists;

[Route("api/v1/price-list")]
public sealed class PriceListController : ApiController
{
    /// <summary>
    /// Добавление позиции в прайс-лист
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] PriceListRequest request, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new AddPriceListCommand(request.OperationId, request.ProductId, request.Price),
            cancellationToken));
    }
    /// <summary>
    /// Получение всех позиций прайс-листа
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof((IReadOnlyCollection<PriceListModel> PriceLists, int TotalCount)), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync([FromQuery] PriceListFilter filter, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllPriceListQuery(filter), cancellationToken);
        return Ok(new {PriceLists = result.PriceLists, TotalCount = result.TotalCount});
    }
}