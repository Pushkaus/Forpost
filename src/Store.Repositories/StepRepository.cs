using AutoMapper;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class StepRepository : Repository<Step>, IStepRepository
{
    public StepRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}