using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.TechCardItem;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface ITechCardItemRepository: IRepository<TechCardItemEntity>
{
    public Task<IReadOnlyCollection<ItemsInTechCardModel>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}