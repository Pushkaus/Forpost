using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.TechCards;

public interface ITechCardReadRepository: IApplicationReadRepository
{
    public Task<CompositionTechCard?> GetCompositionTechCardsAsync(Guid techCardId,
        CancellationToken cancellationToken);
}