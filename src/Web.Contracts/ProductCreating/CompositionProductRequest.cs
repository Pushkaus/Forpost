namespace Forpost.Web.Contracts.ProductCreating;

public sealed class CompositionProductRequest
{
    /// <summary>
    /// Продукт относительно которого заполняем состав
    /// </summary>
    public Guid ProductDevelopmentId { get; set; }
    public IReadOnlyCollection<Guid> CompletedProductsId { get; set; }
}