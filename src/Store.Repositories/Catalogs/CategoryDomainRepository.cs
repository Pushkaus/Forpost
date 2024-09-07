using AutoMapper;
using Forpost.Domain.Catalogs.Category;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class CategoryDomainRepository : DomainRepository<Category>, ICategoryDomainRepository
{
    public CategoryDomainRepository(ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}