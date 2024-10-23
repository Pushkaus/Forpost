using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using Mediator;

namespace Forpost.Features.Catalogs.Products;

internal sealed class ProductCreateCommandHandler : ICommandHandler<AddProductCommand, Guid>
{
    private readonly IProductDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public ProductCreateCommandHandler(IProductDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Guid> Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command);
        return ValueTask.FromResult(_domainRepository.Add(product));
    }
}

public record AddProductCommand(string Name, bool? Purchased, Guid CategoryId) : ICommand<Guid>;
