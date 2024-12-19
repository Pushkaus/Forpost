namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardSteps;

public interface ITechCardStepReadRepository
{
    public Task<EntityPagedResult<TechCardStepModel>> GetTechCardStepsAsync(
        Guid techCardId,
        TechCardStepFilter filter,
        CancellationToken cancellationToken);
    
    public Task<TechCardStepModel> GetTechCardStepAsync(Guid id, CancellationToken cancellationToken);
}