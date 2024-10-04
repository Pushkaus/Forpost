using AutoMapper;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Common;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Features.ProductCreating.ProductsDevelopments;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses;

internal sealed class LauncherManufacturingProcessCommandHandler: ICommandHandler<LaunchManufacturingProcessCommand>
{
    private readonly IManufacturingProcessDomainRepository _domainRepository;
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public LauncherManufacturingProcessCommandHandler(IManufacturingProcessDomainRepository domainRepository, IMapper mapper, ISender sender)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
        _sender = sender;
    }

    public async ValueTask<Unit> Handle(LaunchManufacturingProcessCommand command, CancellationToken cancellationToken)
    {
        var manufacturingProcess = await _domainRepository.GetByIdAsync(command.ManufacturingProcessId, cancellationToken);
        
        manufacturingProcess.EnsureFoundBy(entity => entity.Id, command.ManufacturingProcessId)
            .Launch(command.ManufacturingProcessId);
        
        _domainRepository.Update(manufacturingProcess);
        return Unit.Value;
    }
}

public record LaunchManufacturingProcessCommand(Guid ManufacturingProcessId) : ICommand;