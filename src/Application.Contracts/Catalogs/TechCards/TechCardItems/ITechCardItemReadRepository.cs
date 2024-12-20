using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardItems;

public interface ITechCardItemReadRepository: IApplicationReadRepository
{
    public Task<EntityPagedResult<TechCardItemModel>> GetItemsByTechCardIdAsync(
        Guid techCardId,
        TechCardItemFilter filter,
        CancellationToken cancellationToken);
    
    public Task<TechCardItemModel> GetTechCardItemAsync(Guid id, CancellationToken cancellationToken);
    
}