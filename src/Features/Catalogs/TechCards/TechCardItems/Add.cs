using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardItems;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardItems;

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
        var techCardItem = TechCardItem.Add(command.TechCardId, command.ProductId, command.Quantity);
        return ValueTask.FromResult(_domainRepository.Add(techCardItem));
    }
}

public record AddTechCardItemCommand(Guid TechCardId, Guid ProductId, int Quantity) : ICommand<Guid>;