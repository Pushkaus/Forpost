using AutoMapper;
using Forpost.Domain.Catalogs.Category;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ForpostContextPostgres dbContext,
        TimeProvider timeProvider,
        IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}