using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Crm.InvoiceManagement.Contracts;

public interface IInvoiceDomainRepository : IDomainRepository<Invoice>
{
    public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
}