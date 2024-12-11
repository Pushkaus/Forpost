using Forpost.Domain.Catalogs.Products.Attributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.Attributes;

internal sealed class AddAttributeValuesCommandHandler : ICommandHandler<AddAttributeValuesCommand>
{
    private readonly IAttributeDomainRepository _attributeDomainRepository;

    public AddAttributeValuesCommandHandler(IAttributeDomainRepository attributeDomainRepository)
    {
        _attributeDomainRepository = attributeDomainRepository;
    }

    public async ValueTask<Unit> Handle(AddAttributeValuesCommand valuesCommand, CancellationToken cancellationToken)
    {
        var attribute = await _attributeDomainRepository.GetByIdAsync(valuesCommand.AttributeId, cancellationToken);
        
        attribute!.AddPossibleValue(valuesCommand.AttributeValues);
        
        _attributeDomainRepository.Update(attribute);
        
        return Unit.Value;
    }
}

public record AddAttributeValuesCommand(Guid AttributeId, List<string> AttributeValues) : ICommand;