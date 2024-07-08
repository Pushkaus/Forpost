using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories;

public class InvoiceProductRepository: Repository<InvoiceProduct>, IInvoiceProductRepository
{
    public InvoiceProductRepository(ForpostContextPostgres db) : base(db)
    {
    }
}