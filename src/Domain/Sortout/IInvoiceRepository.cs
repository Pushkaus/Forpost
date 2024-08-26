using Forpost.Common.DataAccess;

namespace Forpost.Domain.Sortout;

public interface IInvoiceRepository : IRepository<Invoice>
{
    public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
}