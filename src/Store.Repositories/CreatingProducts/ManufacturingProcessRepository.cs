using AutoMapper;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class ManufacturingProcessRepository : Repository<ManufacturingProcess>, IManufacturingProcessRepository
{
    public ManufacturingProcessRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}