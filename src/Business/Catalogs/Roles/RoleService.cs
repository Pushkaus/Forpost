using AutoMapper;
using Forpost.EventBus;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Catalogs.Roles;

internal sealed class RoleService : BusinessService, IRoleService
{
    public RoleService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider
    )
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
    }

    public async Task AddAsync(string name, CancellationToken cancellationToken)
    {
        var role = new RoleEntity { Name = name };
        DbUnitOfWork.RoleRepository.Add(role);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<RoleEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbUnitOfWork.RoleRepository.GetAllAsync(cancellationToken);
    }

    public async Task<RoleEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbUnitOfWork.RoleRepository.GetByIdAsync(id, cancellationToken);
    }
}