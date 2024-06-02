using Forpost.Web.Contracts.OrderBlock;
using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Mvc;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;


namespace Forpost.Web.Contracts.Controllers;

[Route("api/v1/order-blocks/")]
[ApiController]
public sealed class OrderBlocksController : ControllerBase
{
    private readonly IOrderBlocksService _orderBlocksService;

    public OrderBlocksController(IOrderBlocksService orderBlocksService)
    {
        _orderBlocksService = orderBlocksService;
    }

    [HttpGet(Name = "GetOrderByAccount")]
    public async Task<ActionResult<List<OrderBlockResponse>>> GetOrderByAccount(string account, CancellationToken cancellationToken)
    {

        var orders = await _orderBlocksService.GetOrdersByAccountNumber(account, cancellationToken);

        var orderResponses = orders.Select(o => new OrderBlockResponse
        {
            Id = o.Id,
            Klient = o.Klient,
            Account = o.Account,
            Block = o.Block,
            Deadline = o.Deadline,
            Amount = o.Amount,
        }).ToList();

        return Ok(orderResponses);
    }

}
