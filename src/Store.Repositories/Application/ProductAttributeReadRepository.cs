using Forpost.Application.Contracts.Catalogs.Products.ProductAttributes;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


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
        var query = await _dbContext.ProductAttributes
            .Where(entity => entity.ProductId == productId)
            .Join(_dbContext.Attributes,
                productAttribute => productAttribute.AttributeId, 
                attribute => attribute.Id,
                (productAttribute, attribute) => new { productAttribute, attribute })
            .Join(_dbContext.Products,
                entity => entity.productAttribute.ProductId,
                product => product.Id,
                (entity, product) => new
                {
                    entity.productAttribute.Id,
                    entity.productAttribute.ProductId,
                    ProductName = product.Name, 
                    AttributeId = entity.attribute.Id,
                    AttributeName = entity.attribute.Name, 
                    ValuesJson = entity.productAttribute.Values
                })
            .ToListAsync(cancellationToken);

        return query.Select(entity => new ProductAttributeModel
        {
            Id = entity.Id,
            ProductId = entity.ProductId,
            ProductName = entity.ProductName,
            AttributeId = entity.AttributeId,
            AttributeName = entity.AttributeName,
            Values = JsonSerializer.Deserialize<List<string>>(entity.ValuesJson) ?? []
        }).ToList();
    }
}