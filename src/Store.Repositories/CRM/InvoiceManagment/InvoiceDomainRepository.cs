using AutoMapper;
using Forpost.Domain.Crm.InvoiceManagement;
using Forpost.Domain.Crm.InvoiceManagement.Contracts;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.CRM.InvoiceManagment;

internal sealed class InvoiceDomainRepository : DomainRepository<Invoice>, IInvoiceDomainRepository
{
    public InvoiceDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken)
    {
        return await DbSet.FirstOrDefaultAsync(entity => entity.Number == number, cancellationToken);
    }
}