using Forpost.Store.Entities;


namespace Forpost.Store.Repositories.Abstract.Repositories
{
    public interface IOrderBlocksRepository
    {
        public Task<List<OrderBlock>> GetOrdersByAccountNumber(string account, CancellationToken cancellationToken);
        
    }
}
