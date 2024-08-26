using System.Diagnostics;
using AutoMapper;
using Forpost.Common;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using MediatR;

namespace Forpost.Application.ProductCreating.ManufacturingProcesses;

internal sealed class LauncherManufacturingProcessCommandHandler: IRequestHandler<LaunchManufacturingProcessCommand>
{
    private readonly IManufacturingProcessRepository _repository;
    private readonly IMapper _mapper;

    public LauncherManufacturingProcessCommandHandler(IManufacturingProcessRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(LaunchManufacturingProcessCommand command, CancellationToken cancellationToken)
    {
        var manufacturingProcess = await _repository.GetByIdAsync(command.ManufacturingProcessId, cancellationToken);
        
        manufacturingProcess.EnsureFoundBy(entity => entity.Id, command.ManufacturingProcessId).Launch();
        
        _repository.Update(manufacturingProcess);
    }
}

public record LaunchManufacturingProcessCommand(Guid ManufacturingProcessId) : IRequest;