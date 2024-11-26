using Forpost.Domain.Catalogs.Products.Attributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.Attributes;

internal sealed class DeleteAttributeByIdCommandHandler: ICommandHandler<DeleteAttributeByIdCommand>
{
    private readonly IAttributeDomainRepository _attributeDomainRepository;

    public DeleteAttributeByIdCommandHandler(IAttributeDomainRepository attributeDomainRepository)
    {
        _attributeDomainRepository = attributeDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteAttributeByIdCommand command, CancellationToken cancellationToken)
    {
        _attributeDomainRepository.DeleteById(command.AttributeId);
        return Unit.ValueTask;
    }
}
public record DeleteAttributeByIdCommand(Guid AttributeId): ICommand;