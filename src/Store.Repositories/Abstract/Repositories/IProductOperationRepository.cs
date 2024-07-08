using System.Collections;
using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IProductOperationRepository: IRepository<ProductOperation>
{
    public Task<IReadOnlyList<ProductOperation>> GetAllByProductId(Guid id);
}