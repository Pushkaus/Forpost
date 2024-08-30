using Forpost.Domain.Catalogs.TechCardItems;
using MediatR;

namespace Forpost.Features.Catalogs.TechCardItems;

internal sealed class GetTechCardItemByIdQueryHandler : IRequestHandler<GetTechCardItemByIdQuery, IReadOnlyCollection<TechCardItem>>
{
    private readonly ITechCardItemDomainRepository _domainRepository;

    public GetTechCardItemByIdQueryHandler(ITechCardItemDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<TechCardItem>> Handle(GetTechCardItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _domainRepository.GetAllItemsByTechCardId(request.TechCardId, cancellationToken);
    }
}

public sealed record GetTechCardItemByIdQuery(Guid TechCardId) : IRequest<IReadOnlyCollection<TechCardItem>>;