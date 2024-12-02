using AutoMapper;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class ManufacturingOrderCompositionDomainRepositoryDomainRepository : DomainRepository<ManufacturingOrderComposition>,
    IManufacturingOrderCompositionDomainRepository
{
    public ManufacturingOrderCompositionDomainRepositoryDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider,
        IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
}