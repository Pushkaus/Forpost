using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed  class InvoiceRepository: Repository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken) 
        => await DbSet.FirstOrDefaultAsync(entity => entity.Number == number, cancellationToken);

    
}