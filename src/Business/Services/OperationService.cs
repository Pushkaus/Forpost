using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Business.Models.Operations;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class OperationService: BusinessService, IOperationService
{
    public OperationService(
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

    public async Task<Guid> AddAsync(OperationModel model, CancellationToken cancellationToken)
    {
        var operation = Mapper.Map<OperationEntity>(model);
        var operationId = DbUnitOfWork.OperationRepository.Add(operation);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return operationId;
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    { 
        DbUnitOfWork.OperationRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<OperationEntity>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.OperationRepository.GetAllAsync(cancellationToken);
}