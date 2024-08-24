using AutoMapper;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class ManufacturingProcessRepository: Repository<ManufacturingProcessEntity>, IManufacturingProcessRepository
{
    public ManufacturingProcessRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }
}