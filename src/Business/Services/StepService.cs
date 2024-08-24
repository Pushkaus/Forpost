using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Business.Models.Steps;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class StepService: BusinessService, IStepService
{
    public StepService(
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

    public async Task<Guid> AddAsync(StepCreateModel model, CancellationToken cancellationToken)
    {
        var step = Mapper.Map<StepEntity>(model);
        var stepId = DbUnitOfWork.StepRepository.Add(step);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return stepId;
    }

    public async Task<StepEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await DbUnitOfWork.StepRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<StepEntity>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.StepRepository.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.StepRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}