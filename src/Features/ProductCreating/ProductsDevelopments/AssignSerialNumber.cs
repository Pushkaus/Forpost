using Forpost.Common;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class AssignSerialNumberCommandHandler: ICommandHandler<AssignSerialNumberCommand>
{
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;

    public AssignSerialNumberCommandHandler(IProductDevelopmentDomainRepository productDevelopmentDomainRepository)
    {
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
    }

    public async ValueTask<Unit> Handle(AssignSerialNumberCommand command, CancellationToken cancellationToken)
    {
        var productDevelopment = await _productDevelopmentDomainRepository
            .GetByIdAsync(command.ProductDevelopmentId, cancellationToken);
        
        productDevelopment.EnsureFoundBy(entity => entity.Id, command.ProductDevelopmentId)
            .SetSerialNumber(command.SerialNumber);
        
        _productDevelopmentDomainRepository.Update(productDevelopment);
        
        return Unit.Value;
    }
}

public record AssignSerialNumberCommand(Guid ProductDevelopmentId, string SerialNumber) : ICommand;
