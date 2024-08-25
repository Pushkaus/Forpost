using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using MediatR;

namespace Forpost.Application.Catalogs.Products;

internal sealed class ProductUpdateCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductUpdateCommandHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command);
        _repository.Update(product);
        return Task.CompletedTask;
    }
}

public record UpdateProductCommand(Guid Id, string Name, string? Version, decimal Cost) : IRequest;
