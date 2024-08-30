using Forpost.Common;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using MediatR;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class AssignSettingOptionCommandHandler: IRequestHandler<AssignSettingOptionCommand>
{
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;

    public AssignSettingOptionCommandHandler(IProductDevelopmentDomainRepository productDevelopmentDomainRepository)
    {
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
    }

    public async Task Handle(AssignSettingOptionCommand command, CancellationToken cancellationToken)
    {
        var productDevelopment = await _productDevelopmentDomainRepository
            .GetByIdAsync(command.ProductDevelopmentId, cancellationToken);
        
        productDevelopment.EnsureFoundBy(entity => entity.Id, command.ProductDevelopmentId)
            .SetSettingOption(command.SettingOption);
        
        _productDevelopmentDomainRepository.Update(productDevelopment);
    }
}
public record AssignSettingOptionCommand(Guid ProductDevelopmentId, SettingOption SettingOption): IRequest;