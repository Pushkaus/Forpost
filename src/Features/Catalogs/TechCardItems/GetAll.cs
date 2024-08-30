using Forpost.Domain.Catalogs.TechCardItems;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardItems;

internal sealed class GetAllTechCardItemsQueryHandler :
    IRequestHandler<GetAllTechCardItemsQuery, IReadOnlyCollection<TechCardItem>>
{
    private readonly ITechCardItemDomainRepository _domainRepository;

    public GetAllTechCardItemsQueryHandler(ITechCardItemDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<TechCardItem>> Handle(GetAllTechCardItemsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardItemsQuery : IRequest<IReadOnlyCollection<TechCardItem>>;