using Forpost.Business.Models.TechCardItems;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface ITechCardItemService: IBusinessService
{
    public Task<Guid> AddAsync(TechCardItemCreateModel model, CancellationToken cancellationToken);
    public Task<TechCardItemEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TechCardItemEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<ItemsInTechCardModel>> GetAllItemsByTechCardId(Guid techCardId,
        CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}