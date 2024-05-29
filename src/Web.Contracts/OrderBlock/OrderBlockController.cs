using Forpost.Web.Contracts.OrderBlock;


using Microsoft.AspNetCore.Mvc;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;


namespace Forpost.Web.Contracts.Controllers;

[Route("api/v1/order-blocks/")]
[ApiController]
public sealed class OrderBlocksController : ControllerBase
{
    private readonly OrderBlockContext _dbContext;

    public OrderBlocksController(OrderBlockContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetOrderByAccount")]
    public async Task<ActionResult<List<OrderBlockResponse>>> GetOrderByAccount(string account)
    {

        var orders = await _dbContext.OrderBlocks.Where(o => o.Account == account).ToListAsync();

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
