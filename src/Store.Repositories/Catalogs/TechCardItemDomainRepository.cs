using AutoMapper;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class TechCardItemDomainRepository : DomainRepository<TechCardItem>, ITechCardItemDomainRepository
{
    public TechCardItemDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyCollection<TechCardItem>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.TechCardId == techCardId).Join(DbContext.Products,
            entity => entity.ProductId,
            product => product.Id,
            (entity, product) => new TechCardItem
            {
                TechCardId = techCardId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                Id = entity.Id
            }).ToListAsync(cancellationToken);
    }
}