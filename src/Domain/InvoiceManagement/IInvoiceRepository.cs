using Forpost.Common.DataAccess;

namespace Forpost.Domain.InvoiceManagement;

public interface IInvoiceRepository : IRepository<Invoice>
{
    public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
}