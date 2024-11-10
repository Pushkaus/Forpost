using Forpost.Domain.Catalogs.Storages;
using Mediator;

namespace Forpost.Features.Catalogs.Storages;

internal sealed class DeleteStorageCommandHandler : ICommandHandler<DeleteStorageCommand>
{
    private readonly IStorageDomainRepository _storageDomainRepository;

    public DeleteStorageCommandHandler(IStorageDomainRepository storageDomainRepository)
    {
        _storageDomainRepository = storageDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteStorageCommand command, CancellationToken cancellationToken)
    {
        _storageDomainRepository.DeleteById(command.StorageId);
        return Unit.ValueTask;
    }
}

public record DeleteStorageCommand(Guid StorageId) : ICommand;