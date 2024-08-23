using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Business.Models.TechCardItems;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class TechCardItemService: BusinessService, ITechCardItemService
{
    public TechCardItemService(
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
    public async Task<Guid> AddAsync(TechCardItemCreateModel model, CancellationToken cancellationToken)
    {
        var techCardItem = Mapper.Map<TechCardItem>(model);
        var techCardItemId = DbUnitOfWork.TechCardItemRepository.Add(techCardItem);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return techCardItemId;
    }

    public async Task<TechCardItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardItemRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<TechCardItem>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardItemRepository.GetAllAsync(cancellationToken);

    public async Task<IReadOnlyCollection<ItemsInTechCardModel>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        var items = await DbUnitOfWork.TechCardItemRepository.GetAllItemsByTechCardId(techCardId, cancellationToken);
        var result = Mapper.Map<IReadOnlyCollection<ItemsInTechCardModel>>(items);
        return result;
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.TechCardItemRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}