using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.CRM.InvoiceManagement.Contracts;

public interface IInvoiceDomainRepository : IDomainRepository<Invoice>
{
    public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
}