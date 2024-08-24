using Forpost.Business.Models.Steps;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface IStepService: IBusinessService
{
    public Task<Guid> AddAsync(StepCreateModel model, CancellationToken cancellationToken);
    public Task<StepEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<StepEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}