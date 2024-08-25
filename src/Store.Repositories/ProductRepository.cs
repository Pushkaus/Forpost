using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}