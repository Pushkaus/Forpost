namespace Forpost.Business.Abstract.Services
{
    public interface IOrderBlocksService : IBusinessService
    {
        public void GetOrder(int id, CancellationToken cancellationToken);

    }
}
