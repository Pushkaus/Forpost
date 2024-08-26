using Forpost.Common;
using Forpost.Domain.Catalogs.Roles;
using MediatR;

namespace Forpost.Application.Catalogs.Roles;

internal sealed class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Role>
{
    private readonly IRoleRepository _repository;

    public GetRoleByIdQueryHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return role.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetRoleByIdQuery(Guid Id) : IRequest<Role>;