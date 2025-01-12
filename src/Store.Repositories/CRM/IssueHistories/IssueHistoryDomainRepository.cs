using AutoMapper;
using Forpost.Domain.Crm.IssueHistory;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CRM.IssueHistories;

internal sealed class IssueHistoryDomainRepository : DomainRepository<IssueHistory>, IIssueHistoryDomainRepository
{
    public IssueHistoryDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }
}