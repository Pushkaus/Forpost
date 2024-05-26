using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

public class OrderBlockRequest(OrderBlockContext context)
{
    private readonly OrderBlockContext _context = context;

    public async Task<OrderBlock> GetOrderBlock() 
    {

        var orderBlock = await _context.OrderBlocks
            .AsNoTracking()
            .FirstOrDefaultAsync(); 

        return orderBlock; 
    }
}
