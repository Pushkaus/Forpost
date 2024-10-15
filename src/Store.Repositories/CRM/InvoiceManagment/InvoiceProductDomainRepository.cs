using AutoMapper;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.CRM.InvoiceManagment;

internal sealed class InvoiceProductDomainRepository : DomainRepository<InvoiceProduct>, IInvoiceProductDomainRepository
{
    public InvoiceProductDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    

    public async Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await DbSet.FirstAsync(entity => entity.ProductId == id, cancellationToken);
        DbSet.Entry(product).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}