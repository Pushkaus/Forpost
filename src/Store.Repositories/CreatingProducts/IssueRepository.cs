using AutoMapper;
using Forpost.Application.Contracts.Issues;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.Sortout;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class IssueRepository : Repository<Issue>, IIssueRepository
{
    public IssueRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    
}