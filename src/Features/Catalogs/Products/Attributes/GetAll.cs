using Forpost.Domain.Catalogs.Products.Attributes;
using Mediator;
using Attribute = Forpost.Domain.Catalogs.Products.Attributes.Attribute;

namespace Forpost.Features.Catalogs.Products.Attributes;

internal sealed class GetAllValueByAttributeIdQueryHandler: IQueryHandler<GetAllValueByAttributeIdQuery, Attribute>
{
    private readonly IAttributeDomainRepository _attributeDomainRepository;

    public GetAllValueByAttributeIdQueryHandler(IAttributeDomainRepository attributeDomainRepository)
    {
        _attributeDomainRepository = attributeDomainRepository;
    }

    public async ValueTask<Attribute> Handle(GetAllValueByAttributeIdQuery query, CancellationToken cancellationToken)
    {
        var attribute = await _attributeDomainRepository.GetByIdAsync(query.AttributeId, cancellationToken);
        return attribute;
    }
}
public record GetAllValueByAttributeIdQuery(Guid AttributeId): IQuery<Attribute>;