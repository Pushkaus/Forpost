using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.TechCardItem;

namespace Forpost.Store.Repositories.Abstract;

public interface ITechCardItemRepository: IRepository<TechCardItem>
{
    public Task<IReadOnlyCollection<ItemsInTechCard>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}