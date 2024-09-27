using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.TechCards;

public interface ITechCardReadRepository: IApplicationReadRepository
{
    public Task<CompositionTechCardModel?> GetCompositionTechCardsAsync(Guid techCardId,
        CancellationToken cancellationToken);
    
    public Task<(IReadOnlyCollection<TechCardModel> TechCards, int TotalCount)> GetAllAsync(
        string? filterExpression, object?[]? filterValues, int skip, int limit, CancellationToken cancellationToken);
}