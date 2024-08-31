using Forpost.Domain.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class GetAllTechCardsQueryHandler :
    IQueryHandler<GetAllTechCardsQuery, IReadOnlyCollection<TechCard>>
{
    private readonly ITechCardDomainRepository _domainRepository;

    public GetAllTechCardsQueryHandler(ITechCardDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<TechCard>> Handle(GetAllTechCardsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardsQuery : IQuery<IReadOnlyCollection<TechCard>>;