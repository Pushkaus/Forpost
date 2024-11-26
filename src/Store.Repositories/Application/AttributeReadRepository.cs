using System.Text.Json;
using Forpost.Application.Contracts.Catalogs.Attributes;
using Forpost.Application.Contracts.Catalogs.Products;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Attribute = Forpost.Domain.Catalogs.Products.Attributes.Attribute;

namespace Forpost.Store.Repositories.Application;

internal sealed class AttributeReadRepository: IAttributeReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public AttributeReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<AttributeModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var attributes = await _dbContext.Attributes.ToListAsync(cancellationToken);

        return attributes.Select(attribute => new AttributeModel
        {
            Id = attribute.Id,
            Name = attribute.Name,
            Values = JsonSerializer.Deserialize<List<string>>(attribute.PossibleValuesJson) ?? [],
        }).ToList(); 
    }

}