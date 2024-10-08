using AutoMapper;
using Forpost.Domain.Catalogs.Roles;
using Mediator;

namespace Forpost.Features.Catalogs.Roles;

//TODO: вынести круды для каталогов в базовый класс
internal sealed class AddRoleCommandHandler : ICommandHandler<AddRoleCommand, Guid>
{
    private readonly IRoleDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddRoleCommandHandler(IRoleDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public async ValueTask<Guid> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var additionItemId = _domainRepository.Add(_mapper.Map<Role>(request));
        return await Task.FromResult(additionItemId);
    }
}

public sealed record AddRoleCommand(string Name) : ICommand<Guid>;