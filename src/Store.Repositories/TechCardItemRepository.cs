using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.TechCardItem;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class TechCardItemRepository: Repository<TechCardItemEntity>, ITechCardItemRepository
{
    public TechCardItemRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyCollection<ItemsInTechCard>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.TechCardId == techCardId).Join(DbContext.Products,
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