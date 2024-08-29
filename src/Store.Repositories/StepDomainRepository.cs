using AutoMapper;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class StepDomainRepository : DomainRepository<Step>, IStepDomainRepository
{
    public StepDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}