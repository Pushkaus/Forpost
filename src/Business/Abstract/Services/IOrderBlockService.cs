using Forpost.Store.Postgres;
using Forpost.Web.Contracts.OrderBlock;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Business.Abstract.Services;

public class OrderBlockService : IBusinessService
{
    private readonly OrderBlockContext _dbContext;

    public OrderBlockService(OrderBlockContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OrderBlockResponse?> GetOrderByAccount(string account)
    {
        // Здесь можно использовать _dbContext для работы с базой данных
       _dbContext.OrderBlocks.Where(o => o.Account == account).FirstOrDefault();

        return null;
    }
}