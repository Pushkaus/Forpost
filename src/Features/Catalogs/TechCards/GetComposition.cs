using Forpost.Application.Contracts.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class GetCompositionTechCardQueryHandler: IQueryHandler<GetCompositionTechCardQuery, CompositionTechCard>
{
    private readonly ITechCardReadRepository _techCardReadRepository;

    public GetCompositionTechCardQueryHandler(ITechCardReadRepository techCardReadRepository)
    {
        _techCardReadRepository = techCardReadRepository;
    }

    public async ValueTask<CompositionTechCard> Handle(GetCompositionTechCardQuery query, CancellationToken cancellationToken)
    {
        var techCardComposition = await _techCardReadRepository
            .GetCompositionTechCardsAsync(query.TechCardId, cancellationToken);
        
        return techCardComposition ?? throw new InvalidOperationException();
    }
}
public record GetCompositionTechCardQuery(Guid TechCardId): IQuery<CompositionTechCard>;