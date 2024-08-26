using AutoMapper;
using Forpost.Domain.Catalogs.Roles;
using MediatR;

namespace Forpost.Application.Catalogs.Roles;

//TODO: вынести круды для каталогов в базовый класс
internal sealed class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Guid>
{
    private readonly IRoleRepository _repository;
    private readonly IMapper _mapper;

    public AddRoleCommandHandler(IRoleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var additionItemId = _repository.Add(_mapper.Map<Role>(request));
        return await Task.FromResult(additionItemId);
    }
}

public sealed record AddRoleCommand(string Name) : IRequest<Guid>;