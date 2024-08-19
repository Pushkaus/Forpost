using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class ManufacturingProcessRepository: Repository<ManufacturingProcess>, IManufacturingProcessRepository
{
    public ManufacturingProcessRepository(ForpostContextPostgres db) : base(db)
    {
    }
}