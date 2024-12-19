using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.TechCards.TechCardSteps;

public interface ITechCardStepDomainRepository : IDomainRepository<TechCardStep>
{
    public Task<IReadOnlyList<TechCardStep>> GetAllStepsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}