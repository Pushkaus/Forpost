using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IRoleService: IBusinessService
{
    public Task Add(string name);
    public Task<IReadOnlyList<Role>> GetAll();
    
}