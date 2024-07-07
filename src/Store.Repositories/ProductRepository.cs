using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Store.Repositories;

public class ProductRepository: Repository<Product>, IProductRepository
{
    public ProductRepository(ForpostContextPostgres db) : base(db)
    {
    }
}