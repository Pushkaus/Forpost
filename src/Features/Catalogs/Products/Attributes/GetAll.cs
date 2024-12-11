using Forpost.Application.Contracts.Catalogs.Attributes;
using Forpost.Application.Contracts.Catalogs.Products.Attributes;
using Forpost.Domain.Catalogs.Products.Attributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.Attributes;

public sealed class
    GetAllAttributesQueryHandler : IQueryHandler<GetAllAttributesQuery, IReadOnlyCollection<AttributeModel>>
{
    private readonly IAttributeReadRepository _attributeReadRepository;

    public GetAllAttributesQueryHandler(IAttributeReadRepository attributeReadRepository)
    {
        _attributeReadRepository = attributeReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<AttributeModel>> Handle(GetAllAttributesQuery query,
        CancellationToken cancellationToken)
        => await _attributeReadRepository.GetAllAsync(cancellationToken);
}

public record GetAllAttributesQuery : IQuery<IReadOnlyCollection<AttributeModel>>;