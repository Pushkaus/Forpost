using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class InvoiceRepository: Repository<Invoice>, IInvoiceRepository
{
    private readonly ForpostContextPostgres _db;
    public InvoiceRepository(ForpostContextPostgres db) : base(db)
    {
        _db = db;
    }

    public async Task<Invoice?> GetByNumberAsync(string number) 
        => await DbSet.FirstOrDefaultAsync(entity => entity.Number == number);

    
}