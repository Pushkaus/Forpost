using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ProductCreating.CompositionProduct;

public interface ICompositionProductReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyCollection<CompositionProductGroupModel>> 
        GetCompositionProduct(Guid productDevelopmentId, CancellationToken cancellationToken);
}