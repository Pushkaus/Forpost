using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardItems;
using Forpost.Domain.Catalogs.TechCards.TechCardItems;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardItems;

internal sealed class
    GetTechCardItemByIdQueryHandler : IQueryHandler<GetTechCardItemByIdQuery, EntityPagedResult<TechCardItemModel>>
{
    private readonly ITechCardItemReadRepository _techCardItemReadRepository;

    public GetTechCardItemByIdQueryHandler(ITechCardItemReadRepository techCardItemReadRepository)
    {
        _techCardItemReadRepository = techCardItemReadRepository;
    }

    public async ValueTask<EntityPagedResult<TechCardItemModel>> Handle(GetTechCardItemByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _techCardItemReadRepository.GetItemsByTechCardIdAsync(request.TechCardId, request.Filter,
            cancellationToken);
    }
}

public sealed record GetTechCardItemByIdQuery(Guid TechCardId, TechCardItemFilter Filter)
    : IQuery<EntityPagedResult<TechCardItemModel>>;