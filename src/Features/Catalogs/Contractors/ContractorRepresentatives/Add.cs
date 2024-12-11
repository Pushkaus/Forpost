using AutoMapper;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors.ContractorRepresentatives;

internal sealed class
    AddContractorRepresentativeCommandHandler : ICommandHandler<AddContractorRepresentativeCommand, Guid>
{
    private readonly IContractorRepresentativesDomainRepository _contractorRepresentativesDomainRepository;
    private readonly IMapper _mapper;

    public AddContractorRepresentativeCommandHandler(
        IContractorRepresentativesDomainRepository contractorRepresentativesDomainRepository, IMapper mapper)
    {
        _contractorRepresentativesDomainRepository = contractorRepresentativesDomainRepository;
        _mapper = mapper;
    }

    public ValueTask<Guid> Handle(AddContractorRepresentativeCommand command, CancellationToken cancellationToken)
    {
        var contractorRepresentative = _mapper.Map<ContractorRepresentative>(command);
        return ValueTask.FromResult(_contractorRepresentativesDomainRepository.Add(contractorRepresentative));
    }
}

public record AddContractorRepresentativeCommand(Guid ContractorId, string Name, string? Post, string? Description)
    : ICommand<Guid>;