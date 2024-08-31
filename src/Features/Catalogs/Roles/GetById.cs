using Forpost.Common;
using Forpost.Domain.Catalogs.Roles;
using Mediator;

namespace Forpost.Features.Catalogs.Roles;

internal sealed class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, Role>
{
    private readonly IRoleDomainRepository _domainRepository;

    public GetRoleByIdQueryHandler(IRoleDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return role.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetRoleByIdQuery(Guid Id) : IQuery<Role>;