using Forpost.Business.Models.Steps;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IStepService: IBusinessService
{
    public Task<Guid> AddAsync(StepCreateModel model, CancellationToken cancellationToken);
    public Task<Step?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Step>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}