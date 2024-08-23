using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class RoleService : BaseBusinessService, IRoleService
{
    public RoleService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BaseBusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        TimeProvider timeProvider
    )
        : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task AddAsync(string name, CancellationToken cancellationToken)
    {
        var role = new Role { Name = name };
        DbUnitOfWork.RoleRepository.Add(role);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Role>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbUnitOfWork.RoleRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbUnitOfWork.RoleRepository.GetByIdAsync(id, cancellationToken);
    }
}