using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Models.TechCardItem;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class TechCardItemRepository: Repository<TechCardItem>, ITechCardItemRepository
{
    public TechCardItemRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyCollection<ItemsInTechCard>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.TechCardId == techCardId).Join(_db.Products,
            entity => entity.ProductId,
            product => product.Id,
            (entity, product) => new ItemsInTechCard
            {
                TechCardId = techCardId,
                ProductId = entity.ProductId,
                ProductName = product.Name,
                Quantity = entity.Quantity,
                Id = entity.Id
            }).ToListAsync(cancellationToken);
    }
}