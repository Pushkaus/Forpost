using Forpost.Domain.Catalogs.Products.Attributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.Attributes;

internal sealed class UpdateAttributeCommandHandler: ICommandHandler<UpdateAttributeCommand>
{
    private readonly IAttributeDomainRepository _attributeDomainRepository;

    public UpdateAttributeCommandHandler(IAttributeDomainRepository attributeDomainRepository)
    {
        _attributeDomainRepository = attributeDomainRepository;
    }

    public async ValueTask<Unit> Handle(UpdateAttributeCommand command, CancellationToken cancellationToken)
    {
        var attribute = await _attributeDomainRepository.GetByIdAsync(command.AttributeId, cancellationToken);
        if (attribute == null) return Unit.Value;
        
        attribute.UpdateName(command.Name);
        attribute.UpdatePossibleValues(command.Values);
        
        _attributeDomainRepository.Update(attribute);
        return Unit.Value;
    }
}
public record UpdateAttributeCommand(Guid AttributeId, string Name, List<string> Values): ICommand;