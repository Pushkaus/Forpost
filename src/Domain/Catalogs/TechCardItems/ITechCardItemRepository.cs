using Forpost.Common.DataAccess;

namespace Forpost.Domain.Catalogs.TechCardItems;

public interface ITechCardItemRepository : IRepository<TechCardItem>
{
    public Task<IReadOnlyCollection<TechCardItem>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}