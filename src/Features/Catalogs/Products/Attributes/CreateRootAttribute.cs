using Forpost.Domain.Catalogs.Products.Attributes;
using Mediator;
using Attribute = Forpost.Domain.Catalogs.Products.Attributes.Attribute;

namespace Forpost.Features.Catalogs.Products.Attributes;

internal sealed class CreateAttributeCommandHandler: ICommandHandler<CreateAttributeCommand, Guid>
{
    private readonly IAttributeDomainRepository _attributeDomainRepository;

    public CreateAttributeCommandHandler(IAttributeDomainRepository attributeDomainRepository)
    {
        _attributeDomainRepository = attributeDomainRepository;
    }

    public ValueTask<Guid> Handle(CreateAttributeCommand command, CancellationToken cancellationToken)
    {
        var attribute = Attribute.Create(command.AttributeName);
        attribute.AddPossibleValue(command.Values);
        var attributeId = _attributeDomainRepository.Add(attribute);
        return ValueTask.FromResult(attributeId);
    }
}
public record CreateAttributeCommand(string AttributeName, List<string> Values): ICommand<Guid>;