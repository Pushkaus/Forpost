using Forpost.Common;
using Forpost.Domain.Catalogs.TechCards;
using MediatR;

namespace Forpost.Application.Catalogs.TechCards;

internal sealed class GetTechCardByIdQueryHandler : IRequestHandler<GetTechCardByIdQuery, TechCard>
{
    private readonly ITechCardDomainRepository _domainRepository;

    public GetTechCardByIdQueryHandler(ITechCardDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<TechCard> Handle(GetTechCardByIdQuery request, CancellationToken cancellationToken)
    {
        var techCard = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return techCard.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetTechCardByIdQuery(Guid Id) : IRequest<TechCard>;