using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.SortOut;

public interface IInvoiceProductDomainRepository : IDomainRepository<InvoiceProduct>
{
    public Task<IReadOnlyList<InvoiceProduct>> GetProductsByInvoiceIdAsync(Guid id,
        CancellationToken cancellationToken);

    public Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken);
}