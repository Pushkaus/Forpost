using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.TechCards;

public interface ITechCardReadRepository: IApplicationReadRepository
{
    public Task<CompositionTechCardModel?> GetCompositionTechCardsAsync(Guid techCardId,
        CancellationToken cancellationToken);
    
    public Task<EntityPagedResult<EntityPagedResult<TechCardModel>>> GetAllAsync(TechCardFilter filter, CancellationToken cancellationToken);
}