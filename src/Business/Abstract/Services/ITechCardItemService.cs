using Forpost.Business.Models.TechCardItems;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface ITechCardItemService: IBusinessService
{
    public Task<Guid> AddAsync(TechCardItem model, CancellationToken cancellationToken);
    public Task<TechCardItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TechCardItem>> GetAllAsync(CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<ItemsInTechCardModel>> GetAllItemsByTechCardId(Guid techCardId,
        CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}