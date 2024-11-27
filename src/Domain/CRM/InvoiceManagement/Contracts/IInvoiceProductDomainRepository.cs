using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.CRM.InvoiceManagement.Contracts;

public interface IInvoiceProductDomainRepository : IDomainRepository<InvoiceProduct>
{
    public Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken);
}