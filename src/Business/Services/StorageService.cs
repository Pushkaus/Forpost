using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Storages;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class StorageService : BaseBusinessService, IStorageService
{
    public StorageService(IDbUnitOfWork dbUnitOfWork,
        ILogger<StorageService> logger,
        IMapper mapper,
        IConfiguration configuration,
        TimeProvider timeProvider) : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task AddAsync(StorageCreateModel model, CancellationToken cancellationToken)
    {
        var storage = Mapper.Map<Storage>(model);
        DbUnitOfWork.StorageRepository.Add(storage);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Storage?>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbUnitOfWork.StorageRepository.GetAllAsync(cancellationToken);
    }
}