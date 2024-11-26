using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Attributes;

public interface IAttributeReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyCollection<AttributeModel>> GetAllAsync(CancellationToken cancellationToken);
}