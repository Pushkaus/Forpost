using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Crm.InvoiceManagement.Contracts;

public interface IInvoiceProductDomainRepository : IDomainRepository<InvoiceProduct>
{
    public Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken);
}