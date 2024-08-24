using AutoMapper;
using Forpost.Business.ProductCreating.ManufacturingProcesses.Services.Abstract;
using Forpost.EventBus;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.ProductCreating.ManufacturingProcesses.Services;

internal sealed class ManufacturingProcessLaunchService: BusinessService, IManufacturingProcessLaunchService
{
    private readonly IManufactureProcessRepository _manufactureProcessRepository;
    public ManufacturingProcessLaunchService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider, IManufactureProcessRepository manufactureProcessRepository)
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
        _manufactureProcessRepository = manufactureProcessRepository;
    }

    public async Task Launch(Guid manufacturingProcessId, CancellationToken cancellationToken)
    {
        var manufacturingProcess = await _manufactureProcessRepository
            .GetPlanningManufacturingProcessByIdAsync(manufacturingProcessId, cancellationToken);

        manufacturingProcess.Launch();
        
        _manufactureProcessRepository.Update(manufacturingProcess);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task Complete()
    {
        throw new NotImplementedException();
    }
}