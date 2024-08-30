using AutoMapper;
using Forpost.Domain.ProductCreating.CompositionCompletedProduct;
using MediatR;

namespace Forpost.Application.ProductCreating.CompositionCompletedProducts;

internal sealed class AddCompositionCompletedProductCommandHandler : IRequestHandler<AddCompositionCompletedProductCommand>
{
    private readonly ICompositionCompletedProduct _compositionCompletedProduct;
    private readonly IMapper _mapper;
    public AddCompositionCompletedProductCommandHandler(ICompositionCompletedProduct compositionCompletedProduct, IMapper mapper)
    {
        _compositionCompletedProduct = compositionCompletedProduct;
        _mapper = mapper;
    }

    public Task Handle(AddCompositionCompletedProductCommand command, CancellationToken cancellationToken)
    {
        var compositionCompletedProduct = _mapper.Map<CompositionCompletedProduct>(command);
        _compositionCompletedProduct.Add(compositionCompletedProduct);
        return Task.CompletedTask;
    }
}
public record AddCompositionCompletedProductCommand(Guid CompletedProductId, Guid CompletedItemId): IRequest;