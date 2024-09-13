using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.SortOut;

public interface IInvoiceProductDomainRepository : IDomainRepository<InvoiceProduct>
{

    
    public Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken);
}