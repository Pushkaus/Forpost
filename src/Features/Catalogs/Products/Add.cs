using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using MediatR;

namespace Forpost.Application.Catalogs.Products;

internal sealed class ProductCreateCommandHandler : IRequestHandler<AddProductCommand, Guid>
{
    private readonly IProductDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public ProductCreateCommandHandler(IProductDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command);
        return Task.FromResult(_domainRepository.Add(product));
    }
}

public record AddProductCommand(string Name, string? Version) : IRequest<Guid>;
