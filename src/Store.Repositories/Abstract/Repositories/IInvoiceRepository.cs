using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IInvoiceRepository : IRepository<InvoiceEntity>
{
    public Task<InvoiceEntity?> GetByNumberAsync(string number, CancellationToken cancellationToken);
}