using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class InvoiceRepository : Repository<InvoiceEntity>, IInvoiceRepository
{
    public InvoiceRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<InvoiceEntity?> GetByNumberAsync(string number, CancellationToken cancellationToken)
    {
        return await DbSet.FirstOrDefaultAsync(entity => entity.Number == number, cancellationToken);
    }
}