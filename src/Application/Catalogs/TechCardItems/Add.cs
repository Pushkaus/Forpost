using AutoMapper;
using Forpost.Domain.Catalogs.TechCardItems;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardItems;

internal sealed class AddTechCardItemCommandHandler : IRequestHandler<AddTechCardItemCommand, Guid>
{
    private readonly ITechCardItemRepository _repository;
    private readonly IMapper _mapper;

    public AddTechCardItemCommandHandler(ITechCardItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(AddTechCardItemCommand command, CancellationToken cancellationToken)
    {
        var techCardItem = _mapper.Map<TechCardItem>(command);
        return Task.FromResult(_repository.Add(techCardItem));
    }
}

public record AddTechCardItemCommand(Guid TechCardId, Guid ProductId, int Quantity) : IRequest<Guid>;