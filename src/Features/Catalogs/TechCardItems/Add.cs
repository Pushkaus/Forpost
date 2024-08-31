using AutoMapper;
using Forpost.Domain.Catalogs.TechCardItems;
using Mediator;

namespace Forpost.Features.Catalogs.TechCardItems;

internal sealed class AddTechCardItemCommandHandler : ICommandHandler<AddTechCardItemCommand, Guid>
{
    private readonly ITechCardItemDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddTechCardItemCommandHandler(ITechCardItemDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Guid> Handle(AddTechCardItemCommand command, CancellationToken cancellationToken)
    {
        var techCardItem = _mapper.Map<TechCardItem>(command);
        return ValueTask.FromResult(_domainRepository.Add(techCardItem));
    }
}

public record AddTechCardItemCommand(Guid TechCardId, Guid ProductId, int Quantity) : ICommand<Guid>;