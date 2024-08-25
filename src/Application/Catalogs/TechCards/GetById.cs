using Forpost.Common;
using Forpost.Domain.Catalogs.TechCards;
using MediatR;

namespace Forpost.Application.Catalogs.TechCards;

internal sealed class GetTechCardByIdQueryHandler : IRequestHandler<GetTechCardByIdQuery, TechCard>
{
    private readonly ITechCardRepository _repository;

    public GetTechCardByIdQueryHandler(ITechCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<TechCard> Handle(GetTechCardByIdQuery request, CancellationToken cancellationToken)
    {
        var techCard = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return techCard.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetTechCardByIdQuery(Guid Id) : IRequest<TechCard>;