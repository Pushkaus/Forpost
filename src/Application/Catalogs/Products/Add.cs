using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using MediatR;

namespace Forpost.Application.Catalogs.Products;

internal sealed class ProductCreateCommandHandler : IRequestHandler<AddProductCommand, Guid>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductCreateCommandHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command);
        return Task.FromResult(_repository.Add(product));
    }
}

public record AddProductCommand(string Name, string? Version, decimal Cost) : IRequest<Guid>;
