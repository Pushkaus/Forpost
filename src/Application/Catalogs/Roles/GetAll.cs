using Forpost.Domain.Catalogs.Roles;
using MediatR;

namespace Forpost.Application.Catalogs.Roles;

internal sealed class GetAllRolesQueryHandler :
    IRequestHandler<GetAllRolesQuery, IReadOnlyCollection<Role>>
{
    private readonly IRoleRepository _repository;

    public GetAllRolesQueryHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Role>> Handle(GetAllRolesQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllRolesQuery : IRequest<IReadOnlyCollection<Role>>;