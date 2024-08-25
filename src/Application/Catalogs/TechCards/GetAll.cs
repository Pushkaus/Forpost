using Forpost.Domain.Catalogs.TechCards;
using MediatR;

namespace Forpost.Application.Catalogs.TechCards;

internal sealed class GetAllTechCardsQueryHandler :
    IRequestHandler<GetAllTechCardsQuery, IReadOnlyCollection<TechCard>>
{
    private readonly ITechCardRepository _repository;

    public GetAllTechCardsQueryHandler(ITechCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<TechCard>> Handle(GetAllTechCardsQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardsQuery : IRequest<IReadOnlyCollection<TechCard>>;