using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IInvoiceRepository : IRepository<Invoice>
{
    public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
}