using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class ComponentRepository: Repository<Component>, IComponentRepository
{
    public ComponentRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<Component>> GetAllById(Guid id)
    {
        return await DbSet.Include(x => x.ParentProduct)
            .Include(x => x.DaughterProduct).Where(entity => entity.ParentId == id).ToListAsync();
    }
}