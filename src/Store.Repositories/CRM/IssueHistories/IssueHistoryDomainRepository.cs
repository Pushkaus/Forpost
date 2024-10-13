using AutoMapper;
using Forpost.Domain.CRM.IssueHistory;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class IssueHistoryDomainRepository : DomainRepository<IssueHistory>, IIssueHistoryDomainRepository
{
    public IssueHistoryDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }
}