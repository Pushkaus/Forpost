using Forpost.Common;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class AssignSettingOptionCommandHandler: ICommandHandler<AssignSettingOptionCommand>
{
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;

    public AssignSettingOptionCommandHandler(IProductDevelopmentDomainRepository productDevelopmentDomainRepository)
    {
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
    }

    public async ValueTask<Unit> Handle(AssignSettingOptionCommand command, CancellationToken cancellationToken)
    {
        var productDevelopment = await _productDevelopmentDomainRepository
            .GetByIdAsync(command.ProductDevelopmentId, cancellationToken);
        
        productDevelopment.EnsureFoundBy(entity => entity.Id, command.ProductDevelopmentId)
            .SetSettingOption(command.SettingOption);
        
        _productDevelopmentDomainRepository.Update(productDevelopment);
        
        return Unit.Value;
    }
}
public record AssignSettingOptionCommand(Guid ProductDevelopmentId, SettingOption SettingOption): ICommand;