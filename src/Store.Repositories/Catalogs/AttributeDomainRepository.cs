using AutoMapper;
using Forpost.Domain.Catalogs.Products.Attributes;
using Forpost.Store.Postgres;
using Attribute = Forpost.Domain.Catalogs.Products.Attributes.Attribute;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class AttributeDomainRepository : DomainRepository<Attribute>, IAttributeDomainRepository
{
    public AttributeDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }
}