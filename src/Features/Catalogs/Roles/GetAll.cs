using Forpost.Domain.Catalogs.Roles;
using MediatR;

namespace Forpost.Features.Catalogs.Roles;

internal sealed class GetAllRolesQueryHandler :
    IRequestHandler<GetAllRolesQuery, IReadOnlyCollection<Role>>
{
    private readonly IRoleDomainRepository _domainRepository;

    public GetAllRolesQueryHandler(IRoleDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<Role>> Handle(GetAllRolesQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllRolesQuery : IRequest<IReadOnlyCollection<Role>>;