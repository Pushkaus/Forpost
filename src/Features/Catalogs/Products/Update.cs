using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using Mediator;

namespace Forpost.Features.Catalogs.Products;

internal sealed class ProductUpdateCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public ProductUpdateCommandHandler(IProductDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Unit> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command);
        _domainRepository.Update(product);
        return ValueTask.FromResult(Unit.Value);
    }
}

public record UpdateProductCommand(Guid Id, string Name, bool Purchased) : ICommand;
