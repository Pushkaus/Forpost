using Forpost.Domain.Catalogs.TechCardItems;
using Mediator;

namespace Forpost.Features.Catalogs.TechCardItems;

internal sealed class GetAllTechCardItemsQueryHandler :
    IQueryHandler<GetAllTechCardItemsQuery, IReadOnlyCollection<TechCardItem>>
{
    private readonly ITechCardItemDomainRepository _domainRepository;

    public GetAllTechCardItemsQueryHandler(ITechCardItemDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<TechCardItem>> Handle(GetAllTechCardItemsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardItemsQuery : IQuery<IReadOnlyCollection<TechCardItem>>;