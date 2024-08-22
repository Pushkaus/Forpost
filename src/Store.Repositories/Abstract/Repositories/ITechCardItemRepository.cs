using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.TechCardItem;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface ITechCardItemRepository: IRepository<TechCardItem>
{
    public Task<IReadOnlyCollection<ItemsInTechCard>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}