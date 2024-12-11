using Forpost.Application.Contracts.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class GetAllTechCardsQueryHandler :
    IQueryHandler<GetAllTechCardsQuery, (IReadOnlyCollection<TechCardModel> TechCards, int TotalCount)>
{
    private readonly ITechCardReadRepository _domainRepository;

    public GetAllTechCardsQueryHandler(ITechCardReadRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<TechCardModel> TechCards, int TotalCount)> Handle(
        GetAllTechCardsQuery request,
        CancellationToken cancellationToken)
    {
        return await _domainRepository.GetAllAsync(request.FilterExpression, request.FilterValues, request.Skip, request.Limit, cancellationToken);
    }
}

public sealed record GetAllTechCardsQuery(
    string? FilterExpression,
    object?[]? FilterValues,
    int Skip,
    int Limit) : IQuery<(IReadOnlyCollection<TechCardModel> TechCards, int TotalCount)>;