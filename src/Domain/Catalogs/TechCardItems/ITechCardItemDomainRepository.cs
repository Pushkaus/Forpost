using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.TechCardItems;

public interface ITechCardItemDomainRepository : IDomainRepository<TechCardItem>
{
    public Task<IReadOnlyCollection<TechCardItem>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}