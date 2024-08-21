using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class ProductDevelopmentRepository: Repository<ProductDevelopment>, IProductDevelopmentRepository
{
    public ProductDevelopmentRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }
}