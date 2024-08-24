using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.TechCardStep;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface ITechCardStepRepositrory: IRepository<TechCardStepEntity>
{
    public Task<IReadOnlyList<StepsInTechCard>> GetAllStepsByTechCardId(Guid techCardId, CancellationToken cancellationToken);
}