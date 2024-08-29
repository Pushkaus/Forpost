using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using MediatR;

namespace Forpost.Application.Catalogs.Products;

internal sealed class ProductUpdateCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public ProductUpdateCommandHandler(IProductDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command);
        _domainRepository.Update(product);
        return Task.CompletedTask;
    }
}

public record UpdateProductCommand(Guid Id, string Name, string? Version) : IRequest;
