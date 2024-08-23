using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Business.Models.TechCardSteps;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

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
    
    public async Task<Guid> AddAsync(TechCardStepCreateModel model, CancellationToken cancellationToken)
    {
        var techCardStep = Mapper.Map<TechCardStep>(model);
        var techCardStepId = DbUnitOfWork.TechCardStepRepository.Add(techCardStep);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return techCardStepId;
    }
    
    public async Task<TechCardStep?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardStepRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyCollection<StepsInTechCardModel>> GetStepsByTechCardIdAsync
        (Guid techCardId, CancellationToken cancellationToken)
    {
        var model = await DbUnitOfWork.TechCardStepRepository.GetAllStepsByTechCardId(techCardId, cancellationToken);
        var result = Mapper.Map<IReadOnlyCollection<StepsInTechCardModel>>(model);
        return result;
    }

    public async Task<IReadOnlyList<TechCardStep>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardStepRepository.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.TechCardStepRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}