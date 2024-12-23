using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardOperations;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardOperations;

internal sealed class UpdateTechCardStepCommandHandler: ICommandHandler<UpdateTechCardOperationCommand>
{
    private readonly ITechCardOperationDomainRepository _techCardOperationRepository;
    private readonly IMapper _mapper;
    
    public UpdateTechCardStepCommandHandler(ITechCardOperationDomainRepository techCardOperationRepository, IMapper mapper)
    {
        _techCardOperationRepository = techCardOperationRepository;
        _mapper = mapper;
    }

    public ValueTask<Unit> Handle(UpdateTechCardOperationCommand command, CancellationToken cancellationToken)
    {
        _techCardOperationRepository.Update(_mapper.Map<TechCardOperation>(command));
        return ValueTask.FromResult(Unit.Value);
    }
}
public record UpdateTechCardOperationCommand(Guid Id, Guid TechCardId, Guid OperationId, int Number) : ICommand;