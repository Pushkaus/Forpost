using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public sealed class SubProductRepository: SubRepository<SubProduct>, ISubProductRepository
{
    public SubProductRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<SubProduct>> GetAllById(Guid id)
    {
        return await DbSet.Include(x => x.ParentProduct)
            .Include(x => x.DaughterProduct).Where(entity => entity.ParentId == id).ToListAsync();
    }
}