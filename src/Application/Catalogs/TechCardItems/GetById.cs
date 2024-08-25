using Forpost.Common;
using Forpost.Domain.Catalogs.TechCardItems;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardItems;

internal sealed class GetTechCardItemByIdQueryHandler : IRequestHandler<GetTechCardItemByIdQuery, TechCardItem>
{
    private readonly ITechCardItemRepository _repository;

    public GetTechCardItemByIdQueryHandler(ITechCardItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<TechCardItem> Handle(GetTechCardItemByIdQuery request, CancellationToken cancellationToken)
    {
        var TechCardItem = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return TechCardItem.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetTechCardItemByIdQuery(Guid Id) : IRequest<TechCardItem>;