using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services
{
    public class OrderBlocksService : IOrderBlocksService
    {
        private readonly IOrderBlocksRepository _orderBlocksRepository;

        public OrderBlocksService(IOrderBlocksRepository orderBlocksRepository)
        {
            _orderBlocksRepository = orderBlocksRepository;
        }

        public Task<List<OrderBlock>> GetOrdersByAccountNumber(string account, CancellationToken cancellationToken)
        {
            var result = _orderBlocksRepository.GetOrdersByAccountNumber(account, cancellationToken);
            return result;
        }
    } 
}

