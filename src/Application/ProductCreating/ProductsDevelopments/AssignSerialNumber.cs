using Forpost.Common;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using MediatR;

namespace Forpost.Application.ProductCreating.ProductsDevelopments;

internal sealed class AssignSerialNumberCommandHandler: IRequestHandler<AssignSerialNumberCommand>
{
    private readonly IProductDevelopmentRepository _productDevelopmentRepository;

    public AssignSerialNumberCommandHandler(IProductDevelopmentRepository productDevelopmentRepository)
    {
        _productDevelopmentRepository = productDevelopmentRepository;
    }

    public async Task Handle(AssignSerialNumberCommand command, CancellationToken cancellationToken)
    {
        var productDevelopment = await _productDevelopmentRepository
            .GetByIdAsync(command.ProductDevelopmentId, cancellationToken);
        
        productDevelopment.EnsureFoundBy(entity => entity.Id, command.ProductDevelopmentId)
            .SetSerialNumber(command.SerialNumber);
        
        _productDevelopmentRepository.Update(productDevelopment);
        
    }
}

public record AssignSerialNumberCommand(Guid ProductDevelopmentId, string SerialNumber) : IRequest;
