using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IRoleService: IBusinessService
{
    public Task AddAsync(string name, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Role>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
}