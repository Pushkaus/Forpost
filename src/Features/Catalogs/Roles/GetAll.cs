using Forpost.Domain.Catalogs.Roles;
using Mediator;

namespace Forpost.Features.Catalogs.Roles;

internal sealed class GetAllRolesQueryHandler :
    IQueryHandler<GetAllRolesQuery, (IReadOnlyCollection<Role> Roles, int TotalCount)>
{
    private readonly IRoleDomainRepository _domainRepository;

    public GetAllRolesQueryHandler(IRoleDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<Role> Roles, int TotalCount)> Handle(GetAllRolesQuery request, 
        CancellationToken cancellationToken)
    {
        var roles = await _domainRepository.GetAllAsync(null, null, cancellationToken);
        return roles;
    }
}
public sealed record GetAllRolesQuery : IQuery<(IReadOnlyCollection<Role> Roles, int TotalCount)>;