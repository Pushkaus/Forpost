using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class IssueRepository: Repository<Issue>, IIssueRepository
{
    public IssueRepository(ForpostContextPostgres db) : base(db)
    {
    }
}