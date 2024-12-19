using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardItems;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardItems;

internal sealed class UpdateTechCardItemCommandHandler : ICommandHandler<UpdateTechCardItemCommand>
{
    private readonly ITechCardItemDomainRepository _techCardItemRepository;

    private readonly IMapper _mapper;

    public UpdateTechCardItemCommandHandler(ITechCardItemDomainRepository techCardItemRepository, IMapper mapper)
    {
        _techCardItemRepository = techCardItemRepository;
        _mapper = mapper;
    }

    public ValueTask<Unit> Handle(UpdateTechCardItemCommand command, CancellationToken cancellationToken)
    {
        _techCardItemRepository.Update(_mapper.Map<TechCardItem>(command));
        return new ValueTask<Unit>(Unit.Value);
    }
}

public record UpdateTechCardItemCommand(
    Guid Id,
    Guid TechCardId,
    Guid ProductId,
    decimal Quantity) : ICommand;