using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts.Catalogs.Products.ProductAttributes;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ProductAttributeReadRepository : IProductAttributeReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ProductAttributeReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ProductAttributeModel>> GetAllAttributesByProductIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        return await _dbContext.ProductAttributes
            .Where(entity => entity.ProductId == productId)
            .Join(_dbContext.Attributes,
                productAttribute => productAttribute.AttributeId, // Corrected join key
                attribute => attribute.Id,
                (productAttribute, attribute) => new { productAttribute, attribute })
            .Join(_dbContext.Products,
                entity => entity.productAttribute.ProductId,
                product => product.Id,
                (entity, product) => new ProductAttributeModel
                {
                    Id = entity.productAttribute.Id,
                    ProductId = entity.productAttribute.ProductId,
                    ProductName = product.Name, // Assuming Product has a Name property
                    AttributeId = entity.attribute.Id,
                    AttributeName = entity.attribute.Name, // Assuming Attribute has a Name property
                    Values = _dbContext.Attributes // Assuming there's a table for attribute values
                        .Where(av => av.Id == entity.attribute.Id)
                        .Select(av => av.PossibleValuesJson) // Assuming AttributeValue has a Value property
                        .ToList()
                })
            .ToListAsync(cancellationToken);
    }

}