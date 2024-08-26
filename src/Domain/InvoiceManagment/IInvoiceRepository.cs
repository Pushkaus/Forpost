using Forpost.Common.DataAccess;
using Forpost.Domain.InvoiceManagment;

namespace Forpost.Domain.Sortout;

public interface IInvoiceRepository : IRepository<Invoice>
{
    public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
}