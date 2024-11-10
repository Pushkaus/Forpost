using AutoMapper;
using Forpost.Domain.Catalogs.Storages;
using Mediator;

namespace Forpost.Features.Catalogs.Storages;

internal sealed class UpdateStorageCommandHandler : ICommandHandler<UpdateStorageCommand>
{
    private readonly IStorageDomainRepository _storageDomainRepository;
    private readonly IMapper _mapper;

    public UpdateStorageCommandHandler(IStorageDomainRepository storageDomainRepository, IMapper mapper)
    {
        _storageDomainRepository = storageDomainRepository;
        _mapper = mapper;
    }

    public ValueTask<Unit> Handle(UpdateStorageCommand command, CancellationToken cancellationToken)
    {
        _storageDomainRepository.Update(_mapper.Map<Storage>(command));
        return ValueTask.FromResult(Unit.Value);
    }
}

public record UpdateStorageCommand(Guid Id, string Name, Guid ResponsibleId) : ICommand;