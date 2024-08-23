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

internal sealed class OperationService: BaseBusinessService, IOperationService
{
    public OperationService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BaseBusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        TimeProvider timeProvider
    )
        : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task<Guid> AddAsync(OperationModel model, CancellationToken cancellationToken)
    {
        var operation = Mapper.Map<Operation>(model);
        var operationId = DbUnitOfWork.OperationRepository.Add(operation);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return operationId;
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    { 
        DbUnitOfWork.OperationRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Operation>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.OperationRepository.GetAllAsync(cancellationToken);
}