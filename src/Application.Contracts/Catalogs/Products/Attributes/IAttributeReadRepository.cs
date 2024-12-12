using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Products.Attributes;

public interface IAttributeReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyCollection<AttributeModel>> GetAllAsync(CancellationToken cancellationToken);
}