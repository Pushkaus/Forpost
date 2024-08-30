using Forpost.Domain.Catalogs.TechCards;
using MediatR;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class GetAllTechCardsQueryHandler :
    IRequestHandler<GetAllTechCardsQuery, IReadOnlyCollection<TechCard>>
{
    private readonly ITechCardDomainRepository _domainRepository;

    public GetAllTechCardsQueryHandler(ITechCardDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<TechCard>> Handle(GetAllTechCardsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardsQuery : IRequest<IReadOnlyCollection<TechCard>>;