using AutoMapper;
using Forpost.EventBus;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Catalogs.TechCardItems;

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
    public async Task<Guid> AddAsync(TechCardItemCreateCommand model, CancellationToken cancellationToken)
    {
        var techCardItem = Mapper.Map<TechCardItemEntity>(model);
        var techCardItemId = DbUnitOfWork.TechCardItemRepository.Add(techCardItem);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return techCardItemId;
    }

    public async Task<TechCardItemEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardItemRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<TechCardItemEntity>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardItemRepository.GetAllAsync(cancellationToken);

    public async Task<IReadOnlyCollection<ItemsInTechCard>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        var items = await DbUnitOfWork.TechCardItemRepository.GetAllItemsByTechCardId(techCardId, cancellationToken);
        var result = Mapper.Map<IReadOnlyCollection<ItemsInTechCard>>(items);
        return result;
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.TechCardItemRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}