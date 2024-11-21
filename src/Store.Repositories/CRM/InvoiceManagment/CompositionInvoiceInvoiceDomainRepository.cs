using AutoMapper;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CRM.InvoiceManagment;

internal sealed class CompositionInvoiceInvoiceDomainRepository : DomainRepository<CompositionInvoice>,
    ICompositionInvoiceDomainRepository
{
    public CompositionInvoiceInvoiceDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider,
        IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
}