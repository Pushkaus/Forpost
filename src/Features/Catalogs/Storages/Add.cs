using AutoMapper;
using Forpost.Domain.Catalogs.Storages;
using Mediator;

namespace Forpost.Features.Catalogs.Storages;

internal sealed class AddStorageCommandHandler : ICommandHandler<AddStorageCommand, Guid>
{
    private readonly IStorageDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddStorageCommandHandler(IStorageDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Guid> Handle(AddStorageCommand command, CancellationToken cancellationToken)
    {
        var storage = new Storage()
        {
            Name = command.Name,
            ResponsibleId = command.ResponsibleId,
        };
        return ValueTask.FromResult(_domainRepository.Add(storage));
    }
}

public record AddStorageCommand(string Name, Guid ResponsibleId) : ICommand<Guid>;
