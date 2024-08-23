using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Store.Repositories;

internal sealed class StepRepository: Repository<Step>, IStepRepository
{
    public StepRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }
}