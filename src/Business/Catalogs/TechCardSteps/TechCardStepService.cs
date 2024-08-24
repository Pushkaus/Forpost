using AutoMapper;
using Forpost.EventBus;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Catalogs.TechCardSteps;

internal sealed class TechCardStepService: BusinessService, ITechCardStepService
{
    public TechCardStepService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider
    )
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
    }
    
    public async Task<Guid> AddAsync(TechCardStepCreateCommand model, CancellationToken cancellationToken)
    {
        var techCardStep = Mapper.Map<TechCardStepEntity>(model);
        var techCardStepId = DbUnitOfWork.TechCardStepRepository.Add(techCardStep);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return techCardStepId;
    }
    
    public async Task<TechCardStepEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardStepRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyCollection<StepsInTechCard>> GetStepsByTechCardIdAsync
        (Guid techCardId, CancellationToken cancellationToken)
    {
        var model = await DbUnitOfWork.TechCardStepRepository.GetAllStepsByTechCardId(techCardId, cancellationToken);
        var result = Mapper.Map<IReadOnlyCollection<StepsInTechCard>>(model);
        return result;
    }

    public async Task<IReadOnlyList<TechCardStepEntity>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardStepRepository.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.TechCardStepRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}