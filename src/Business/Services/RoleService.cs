using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class RoleService: IRoleService
{
    private readonly IRoleRepository _roleRepository;
    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task Add(string name)
    {
        var role = new Role(name);
        await _roleRepository.AddAsync(role);
        
    }

    public async Task<IReadOnlyList<Role>> GetAll()
    {
        return await _roleRepository.GetAllAsync();
    }

    public async Task<Role?> GetById(Guid id)
    {
        return await _roleRepository.GetByIdAsync(id);
    }
}