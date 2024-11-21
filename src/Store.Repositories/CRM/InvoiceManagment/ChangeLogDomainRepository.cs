using AutoMapper;
using Forpost.Domain.ChangeLogs;
using Forpost.Domain.ChangeLogs.Contracts;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CRM.InvoiceManagment;

internal sealed class ChangeLogDomainRepository : DomainRepository<ChangeLog>, IChangeLogDomainRepository
{
    public ChangeLogDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }
}