using AutoMapper;
using Forpost.Domain.InvoiceManagment;
using Forpost.Domain.Sortout;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken)
    {
        return await DbSet.FirstOrDefaultAsync(entity => entity.Number == number, cancellationToken);
    }
}