using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services.CreatingProducts;
using Forpost.Business.EventHanding;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services.CreatingProducts;

internal sealed class ManufacturingProcessLaunchService: BusinessService, IManufacturingProcessLaunchService
{
    public ManufacturingProcessLaunchService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider)
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
    }

    public async Task Launch(Guid manufacturingProcessId, CancellationToken cancellationToken)
    {
        var model = await DbUnitOfWork.ManufacturingProcessRepository.
            GetByIdAsync(manufacturingProcessId, cancellationToken);
        
        var manufacturingProcess = Mapper.Map<ManufacturingProcess>(model);
        
        manufacturingProcess.StartTime = TimeProvider.GetUtcNow();
        manufacturingProcess.Status = (ManufacturingProcessStatus)200;
        
        DbUnitOfWork.ManufacturingProcessRepository.Update(manufacturingProcess);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task Complete()
    {
        throw new NotImplementedException();
    }
}