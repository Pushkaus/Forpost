using AutoMapper;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class ManufacturingOrderDomainRepositoryDomainRepository : DomainRepository<ManufacturingOrder>, IManufacturingOrderDomainRepository
{
    public ManufacturingOrderDomainRepositoryDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider,
        IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
}