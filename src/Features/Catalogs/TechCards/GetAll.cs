using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class GetAllTechCardsQueryHandler :
    IQueryHandler<GetAllTechCardsQuery, EntityPagedResult<TechCardModel>>
{
    private readonly ITechCardReadRepository _techCardReadRepository;

    public GetAllTechCardsQueryHandler(ITechCardReadRepository techCardReadRepository)
    {
        _techCardReadRepository = techCardReadRepository;
    }

    public async ValueTask<EntityPagedResult<TechCardModel>> Handle(
        GetAllTechCardsQuery request,
        CancellationToken cancellationToken)
    {
        return await _techCardReadRepository.GetAllAsync(request.Filter, cancellationToken);
    }
}

public sealed record GetAllTechCardsQuery(
    TechCardFilter Filter) : IQuery<EntityPagedResult<TechCardModel>>;