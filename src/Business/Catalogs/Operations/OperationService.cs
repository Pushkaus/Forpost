using AutoMapper;
using Forpost.EventBus;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Catalogs.Operations;

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

    public async Task<Guid> AddAsync(Operation model, CancellationToken cancellationToken)
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