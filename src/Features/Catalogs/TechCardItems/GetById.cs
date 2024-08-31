using Forpost.Domain.Catalogs.TechCardItems;
using Mediator;

namespace Forpost.Features.Catalogs.TechCardItems;

internal sealed class GetTechCardItemByIdQueryHandler : IQueryHandler<GetTechCardItemByIdQuery, IReadOnlyCollection<TechCardItem>>
{
    private readonly ITechCardItemDomainRepository _domainRepository;

    public GetTechCardItemByIdQueryHandler(ITechCardItemDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<TechCardItem>> Handle(GetTechCardItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _domainRepository.GetAllItemsByTechCardId(request.TechCardId, cancellationToken);
    }
}

public sealed record GetTechCardItemByIdQuery(Guid TechCardId) : IQuery<IReadOnlyCollection<TechCardItem>>;