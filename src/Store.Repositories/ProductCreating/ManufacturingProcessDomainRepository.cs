using AutoMapper;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class ManufacturingProcessDomainRepository : DomainRepository<ManufacturingProcess>, IManufacturingProcessDomainRepository
{
    public ManufacturingProcessDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}