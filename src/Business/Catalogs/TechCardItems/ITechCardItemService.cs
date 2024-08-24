using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.TechCardItems;

public interface ITechCardItemService: IBusinessService
{
    public Task<Guid> AddAsync(TechCardItemCreateCommand model, CancellationToken cancellationToken);
    public Task<TechCardItemEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TechCardItemEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<ItemsInTechCard>> GetAllItemsByTechCardId(Guid techCardId,
        CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}