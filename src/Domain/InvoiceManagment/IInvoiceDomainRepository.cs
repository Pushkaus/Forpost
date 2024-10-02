using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.InvoiceManagement;

public interface IInvoiceDomainRepository : IDomainRepository<Invoice>
{
    public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
}