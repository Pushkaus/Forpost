using Forpost.Common;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using MediatR;

namespace Forpost.Application.ProductCreating.ProductsDevelopments;

internal sealed class AssignSettingOptionCommandHandler: IRequestHandler<AssignSettingOptionCommand>
{
    private readonly IProductDevelopmentRepository _productDevelopmentRepository;

    public AssignSettingOptionCommandHandler(IProductDevelopmentRepository productDevelopmentRepository)
    {
        _productDevelopmentRepository = productDevelopmentRepository;
    }

    public async Task Handle(AssignSettingOptionCommand command, CancellationToken cancellationToken)
    {
        var productDevelopment = await _productDevelopmentRepository
            .GetByIdAsync(command.ProductDevelopmentId, cancellationToken);
        
        productDevelopment.EnsureFoundBy(entity => entity.Id, command.ProductDevelopmentId)
            .SetSettingOption(command.SettingOption);
        
        _productDevelopmentRepository.Update(productDevelopment);
    }
}
public record AssignSettingOptionCommand(Guid ProductDevelopmentId, SettingOption SettingOption): IRequest;