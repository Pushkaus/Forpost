using System.Collections;
using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface ISubProductRepository: IRepository<SubProduct>
{
    public Task<IReadOnlyList<SubProduct>> GetAllById(Guid id);
}