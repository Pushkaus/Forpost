using AutoMapper;
using Forpost.EventBus;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Catalogs.Storages;

internal sealed class StorageService : BusinessService, IStorageService
{
    public StorageService(
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

    public async Task AddAsync(StorageCreateCommand model, CancellationToken cancellationToken)
    {
        var storage = Mapper.Map<StorageEntity>(model);
        DbUnitOfWork.StorageRepository.Add(storage);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<StorageEntity?>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbUnitOfWork.StorageRepository.GetAllAsync(cancellationToken);
    }
}