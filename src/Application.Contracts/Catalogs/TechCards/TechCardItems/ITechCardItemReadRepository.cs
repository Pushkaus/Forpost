namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardItems;

public interface ITechCardItemReadRepository
{
    public Task<EntityPagedResult<TechCardItemModel>> GetTechCardItemsAsync(
        TechCardItemFilter filter,
        CancellationToken cancellationToken);
    
    public Task<TechCardItemModel> GetTechCardItemAsync(Guid id, CancellationToken cancellationToken);
    
}