using Forpost.Common;
using Forpost.Domain.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class GetTechCardByIdQueryHandler : IQueryHandler<GetTechCardByIdQuery, TechCard>
{
    private readonly ITechCardDomainRepository _domainRepository;

    public GetTechCardByIdQueryHandler(ITechCardDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<TechCard> Handle(GetTechCardByIdQuery request, CancellationToken cancellationToken)
    {
        var techCard = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return techCard.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetTechCardByIdQuery(Guid Id) : IQuery<TechCard>;