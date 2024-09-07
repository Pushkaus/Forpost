using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.CompletedProduct;

/// <summary>
/// Завершенный продукт
/// </summary>
public sealed class CompletedProduct : DomainEntity
{
    public CompletedProduct Create(Guid manufacturingProcessId, Guid productDevelopmentId)
    {
        var completedProduct = new CompletedProduct()
        {
            ManufacturingProcessId = manufacturingProcessId,
            ProductDevelopmentId = productDevelopmentId
        };
        return completedProduct;
    }
    public Guid ManufacturingProcessId { get; set; }
    public Guid ProductDevelopmentId { get; set; }

    /// <summary>
    /// Номер счета, в который уйдет продукт
    /// </summary>
    public Guid? InvoiceId { get; set; }
}