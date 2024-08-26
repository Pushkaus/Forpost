using AutoMapper;
using Forpost.Domain.Catalogs.Storages;
using MediatR;

namespace Forpost.Application.Catalogs.Storages;

internal sealed class AddStorageCommandHandler : IRequestHandler<AddStorageCommand, Guid>
{
    private readonly IStorageRepository _repository;
    private readonly IMapper _mapper;

    public AddStorageCommandHandler(IStorageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(AddStorageCommand command, CancellationToken cancellationToken)
    {
        var storage = _mapper.Map<Storage>(command);
        return Task.FromResult(_repository.Add(storage));
    }
}

public class AddStorageCommand(string Name, Guid ResponsibleId) : IRequest<Guid>;
