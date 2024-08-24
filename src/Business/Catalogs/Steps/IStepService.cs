using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.Steps;

public interface IStepService: IBusinessService
{
    public Task<Guid> AddAsync(StepCreateCommand model, CancellationToken cancellationToken);
    public Task<StepEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<StepEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}