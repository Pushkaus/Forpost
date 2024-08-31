using AutoMapper;
using Forpost.Common;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses;

internal sealed class LauncherManufacturingProcessCommandHandler: ICommandHandler<LaunchManufacturingProcessCommand>
{
    private readonly IManufacturingProcessDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public LauncherManufacturingProcessCommandHandler(IManufacturingProcessDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public async ValueTask<Unit> Handle(LaunchManufacturingProcessCommand command, CancellationToken cancellationToken)
    {
        var manufacturingProcess = await _domainRepository.GetByIdAsync(command.ManufacturingProcessId, cancellationToken);
        
        manufacturingProcess.EnsureFoundBy(entity => entity.Id, command.ManufacturingProcessId).Launch();
        
        _domainRepository.Update(manufacturingProcess);
        
        return Unit.Value;
    }
}

public record LaunchManufacturingProcessCommand(Guid ManufacturingProcessId) : ICommand;