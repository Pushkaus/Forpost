using AutoMapper;
using Forpost.Domain.Catalogs.Contractors;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

public class UpdateContractorCommandHandler : ICommandHandler<UpdateContractorCommand>
{
    private readonly IContractorDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public UpdateContractorCommandHandler(IContractorDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Unit> Handle(UpdateContractorCommand command, CancellationToken cancellationToken)
    {
        var contractor = _mapper.Map<Contractor>(command);
        _domainRepository.Update(contractor);
        return ValueTask.FromResult(Unit.Value);
    }
}

public record UpdateContractorCommand(Guid Id, string Name) : ICommand;