using System.Text.Json;
using Forpost.Application.Contracts.Catalogs.Attributes;
using Forpost.Domain.Catalogs.Products.Attributes;
using Mediator;
using Attribute = Forpost.Domain.Catalogs.Products.Attributes.Attribute;

namespace Forpost.Features.Catalogs.Products.Attributes;

internal sealed class
    GetAllValueByAttributeIdQueryHandler : IQueryHandler<GetAllValueByAttributeIdQuery, AttributeModel>
{
    private readonly IAttributeDomainRepository _attributeDomainRepository;

    public GetAllValueByAttributeIdQueryHandler(IAttributeDomainRepository attributeDomainRepository)
    {
        _attributeDomainRepository = attributeDomainRepository;
    }

    public async ValueTask<AttributeModel> Handle(GetAllValueByAttributeIdQuery query,
        CancellationToken cancellationToken)
    {
        var attribute = await _attributeDomainRepository.GetByIdAsync(query.AttributeId, cancellationToken);
        return new AttributeModel
        {
            Id = attribute.Id,
            Name = attribute.Name,
            Values = JsonSerializer.Deserialize<List<string>>(attribute.PossibleValuesJson) ?? [],
        };
    }
}
public record GetAllValueByAttributeIdQuery(Guid AttributeId) : IQuery<AttributeModel>;
