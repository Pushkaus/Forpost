using Forpost.Domain.Catalogs.TechCardItems;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardItems;

internal sealed class GetTechCardItemByIdQueryHandler : IRequestHandler<GetTechCardItemByIdQuery, IReadOnlyCollection<TechCardItem>>
{
    private readonly ITechCardItemRepository _repository;

    public GetTechCardItemByIdQueryHandler(ITechCardItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<TechCardItem>> Handle(GetTechCardItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllItemsByTechCardId(request.TechCardId, cancellationToken);
    }
}

public sealed record GetTechCardItemByIdQuery(Guid TechCardId) : IRequest<IReadOnlyCollection<TechCardItem>>;