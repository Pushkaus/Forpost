using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.TechCardSteps;

public interface ITechCardStepService: IBusinessService
{
    public Task<Guid> AddAsync(TechCardStepCreateCommand model, CancellationToken cancellationToken);
    public Task<TechCardStepEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<StepsInTechCard>> GetStepsByTechCardIdAsync
        (Guid techCardId, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TechCardStepEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}