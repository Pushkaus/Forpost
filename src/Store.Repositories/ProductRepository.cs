using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories;

internal sealed  class ProductRepository: Repository<Product>, IProductRepository
{
    public ProductRepository(ForpostContextPostgres db) : base(db)
    {
    }
}