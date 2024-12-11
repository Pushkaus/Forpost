using AutoMapper;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors.ContractorRepresentatives;

internal sealed class
    UpdateContractorRepresentativeByIdCommandHandler : ICommandHandler<UpdateContractorRepresentativeByIdCommand>
{
    private readonly IContractorRepresentativesDomainRepository _contractorRepresentativesDomainRepository;
    private readonly IMapper _mapper;

    public UpdateContractorRepresentativeByIdCommandHandler(
        IContractorRepresentativesDomainRepository contractorRepresentativesDomainRepository, IMapper mapper)
    {
        _contractorRepresentativesDomainRepository = contractorRepresentativesDomainRepository;
        _mapper = mapper;
    }

    public async ValueTask<Unit> Handle(UpdateContractorRepresentativeByIdCommand command,
        CancellationToken cancellationToken)
    {
        var contractorRepresentative = _mapper.Map<ContractorRepresentative>(command);
        _contractorRepresentativesDomainRepository.Update(contractorRepresentative);
        return Unit.Value;
    }
}

public record UpdateContractorRepresentativeByIdCommand(
    Guid Id,
    Guid ContractorId,
    string Name,
    string? Post,
    string? Description) : ICommand;