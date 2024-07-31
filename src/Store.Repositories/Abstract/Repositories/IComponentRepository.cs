using System.Collections;
using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IComponentRepository: IRepository<Component>
{
    public Task<IReadOnlyList<Component>> GetAllById(Guid id);
}