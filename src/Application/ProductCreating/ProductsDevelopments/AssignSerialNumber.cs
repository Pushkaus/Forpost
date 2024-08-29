using Forpost.Common;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using MediatR;

namespace Forpost.Application.ProductCreating.ProductsDevelopments;

internal sealed class AssignSerialNumberCommandHandler: IRequestHandler<AssignSerialNumberCommand>
{
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;

    public AssignSerialNumberCommandHandler(IProductDevelopmentDomainRepository productDevelopmentDomainRepository)
    {
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
    }

    public async Task Handle(AssignSerialNumberCommand command, CancellationToken cancellationToken)
    {
        var productDevelopment = await _productDevelopmentDomainRepository
            .GetByIdAsync(command.ProductDevelopmentId, cancellationToken);
        
        productDevelopment.EnsureFoundBy(entity => entity.Id, command.ProductDevelopmentId)
            .SetSerialNumber(command.SerialNumber);
        
        _productDevelopmentDomainRepository.Update(productDevelopment);
        
    }
}

public record AssignSerialNumberCommand(Guid ProductDevelopmentId, string SerialNumber) : IRequest;
