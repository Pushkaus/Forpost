using Forpost.Domain.ProductCreating.CompositionProduct;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class SetCompositionProductCommandHandler: ICommandHandler<SetCompositionProductCommand>
{
    private readonly ICompositionProductRepository _compositionProductRepository;

    public SetCompositionProductCommandHandler(ICompositionProductRepository compositionProductRepository)
    {
        _compositionProductRepository = compositionProductRepository;
    }

    public ValueTask<Unit> Handle(SetCompositionProductCommand command, CancellationToken cancellationToken)
    {
        foreach (var completedProductId in command.CompletedProductsId)
        {
            _compositionProductRepository.Add(CompositionProduct.Create(command.ProductDevelopmentId, completedProductId));
        }
        return ValueTask.FromResult(Unit.Value);
    }
}
public record SetCompositionProductCommand(Guid ProductDevelopmentId, IReadOnlyCollection<Guid> CompletedProductsId): ICommand;