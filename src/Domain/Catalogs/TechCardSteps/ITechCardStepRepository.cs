using Forpost.Common.DataAccess;

namespace Forpost.Domain.Catalogs.TechCardSteps;

public interface ITechCardStepRepository : IRepository<TechCardStep>
{
    public Task<IReadOnlyList<TechCardStep>> GetAllStepsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}