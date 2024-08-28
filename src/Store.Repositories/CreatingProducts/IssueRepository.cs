using AutoMapper;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class IssueRepository : Repository<Issue>, IIssueRepository
{
    public IssueRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    
}