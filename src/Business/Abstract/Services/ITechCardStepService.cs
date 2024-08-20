using Forpost.Business.Models.TechCardSteps;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface ITechCardStepService: IBusinessService
{
    public Task<Guid> AddAsync(TechCardStepCreateModel model, CancellationToken cancellationToken);
    public Task<TechCardStep?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<StepsInTechCardModel>> GetStepsByTechCardIdAsync
        (Guid techCardId, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TechCardStep>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}