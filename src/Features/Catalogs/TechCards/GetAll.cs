using Forpost.Domain.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class GetAllTechCardsQueryHandler :
    IQueryHandler<GetAllTechCardsQuery, (IReadOnlyCollection<TechCard> TechCards, int TotalCount)>
{
    private readonly ITechCardDomainRepository _domainRepository;

    public GetAllTechCardsQueryHandler(ITechCardDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<TechCard> TechCards, int TotalCount)> Handle(GetAllTechCardsQuery request,
        CancellationToken cancellationToken) =>
        await _domainRepository.GetAllAsync(cancellationToken, request.Skip, request.Limit);
}

public sealed record GetAllTechCardsQuery(int Skip, int Limit) : IQuery<(IReadOnlyCollection<TechCard> TechCards, int TotalCount)>;