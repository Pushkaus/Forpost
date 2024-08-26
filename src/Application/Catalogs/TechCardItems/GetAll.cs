using Forpost.Domain.Catalogs.TechCardItems;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardItems;

internal sealed class GetAllTechCardItemsQueryHandler :
    IRequestHandler<GetAllTechCardItemsQuery, IReadOnlyCollection<TechCardItem>>
{
    private readonly ITechCardItemRepository _repository;

    public GetAllTechCardItemsQueryHandler(ITechCardItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<TechCardItem>> Handle(GetAllTechCardItemsQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardItemsQuery : IRequest<IReadOnlyCollection<TechCardItem>>;