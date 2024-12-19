namespace Forpost.Application.Contracts.Catalogs.TechCards.Steps;

public interface IStepReadRepository
{
    public Task<EntityPagedResult<StepModel>> GetAllStepsAsync(StepFilter filter, CancellationToken cancellationToken);
    public Task<StepModel> GetStepByIdAsync(Guid stepId, CancellationToken cancellationToken);
}