using AutoMapper;
using Forpost.Domain.InvoiceManagement;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.InvoiceManagment;

internal sealed class CompositionInvoiceInvoiceDomainRepository : DomainRepository<CompositionInvoice>,
    ICompositionInvoiceDomainRepository
{
    public CompositionInvoiceInvoiceDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider,
        IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
}