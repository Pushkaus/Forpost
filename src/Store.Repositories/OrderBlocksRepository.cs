using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories
{
    public class OrderBlocksRepository : IOrderBlocksRepository
    {
        private readonly OrderBlockContext _dbContext;
        public OrderBlocksRepository(OrderBlockContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<OrderBlock>> GetOrdersByAccountNumber(string account, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.OrderBlocks.Where(o => o.Account == account).ToListAsync();
            return orders;
        }
        
    }
}
