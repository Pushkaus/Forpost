using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.TechCards.TechCardOperations;

public interface ITechCardOperationDomainRepository : IDomainRepository<TechCardOperation>
{
    public Task<IReadOnlyList<TechCardOperation>> GetAllOperationsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}