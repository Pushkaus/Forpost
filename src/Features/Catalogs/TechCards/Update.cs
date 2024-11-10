using AutoMapper;
using Forpost.Domain.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class UpdateTechCardCommandHandler: ICommandHandler<UpdateTechCardCommand>
{
    private readonly ITechCardDomainRepository _techCardRepository;
    private readonly IMapper _mapper;
    
    public UpdateTechCardCommandHandler(ITechCardDomainRepository techCardRepository, IMapper mapper)
    {
        _techCardRepository = techCardRepository;
        _mapper = mapper;
    }

    public ValueTask<Unit> Handle(UpdateTechCardCommand command, CancellationToken cancellationToken)
    {
        _techCardRepository.Update(_mapper.Map<TechCard>(command));
        return new ValueTask<Unit>(Unit.Value);
    }
}
public record UpdateTechCardCommand(Guid Id, string Number, string? Description, Guid ProductId) : ICommand;
