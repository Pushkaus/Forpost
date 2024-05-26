using Forpost.Store.Postgres;
using Forpost.Web.Contracts.OrderBlock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Forpost.Web.Contracts.Controllers;

[Route("api/order-blocks")]
[ApiController]
public class OrderBlocksController : ControllerBase
{
    private readonly OrderBlockContext _dbContext;
    public OrderBlocksController(OrderBlockContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderBlockResponse>>> GetOrderBlocks()
    {
        var randomRecords = _dbContext.OrderBlocks
        .OrderBy(x => Guid.NewGuid())
        .Take(3) // �������� ���������� ������� �� 3
        .ToList();

        var responses = new List<OrderBlockResponse>();

        // ����������� ������ � OrderBlockResponse
        foreach (var record in randomRecords)
        {
            responses.Add(new OrderBlockResponse(
                Id: record.Id, // ���������� Id �� ������� OrderBlock
                Klient: record.Klient, // ���������� Klient �� ������� OrderBlock
                Account: record.Account, // ���������� Account �� ������� OrderBlock
                Block: record.Block 
            ));
        }
        Console.Write(responses);

        return Ok(responses);
    } 
}
